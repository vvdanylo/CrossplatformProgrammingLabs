using System.Globalization;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class AssetsController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    public IActionResult Search()
    {
        var viewModel = new AssetSearchViewModel
        {
            LifeCycleEventStartDate = DateTime.UtcNow.Date,
            LifeCycleEventEndDate = DateTime.UtcNow.Date.AddDays(7)
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Search(AssetSearchViewModel searchModel)
    {
        var query = _context.Assets
            .Include(a => a.RefAssetType)
            .Include(a => a.RefSize)
            .Include(a => a.AssetsLifeCycleEvents)
                .ThenInclude(alce => alce.LifeCyclePhase)
            .Include(a => a.AssetsLifeCycleEvents)
                .ThenInclude(alce => alce.ResponsibleParty)
            .Include(a => a.AssetsLifeCycleEvents)
                .ThenInclude(alce => alce.Location)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchModel.AssetName))
        {
            var searchTerm = searchModel.AssetName.Trim().ToLower(CultureInfo.InvariantCulture);
            query = query.Where(a => a.AssetName.ToLower().Contains(searchTerm));
        }

        if (!string.IsNullOrWhiteSpace(searchModel.AssetTypeCode))
        {
            query = query.Where(a => a.AssetTypeCode == searchModel.AssetTypeCode);
        }

        if (!string.IsNullOrWhiteSpace(searchModel.SizeCode))
        {
            query = query.Where(a => a.SizeCode == searchModel.SizeCode);
        }

        if (!string.IsNullOrWhiteSpace(searchModel.StatusCode))
        {
            query = query.Where(a => a.AssetsLifeCycleEvents.Any(alce => alce.StatusCode == searchModel.StatusCode));
        }

        if (searchModel.LifeCycleEventStartDate.HasValue)
        {
            query = query.Where(a => a.AssetsLifeCycleEvents.Any(alce => alce.DateFrom >= searchModel.LifeCycleEventStartDate.Value));
        }

        if (searchModel.LifeCycleEventEndDate.HasValue)
        {
            var endDate = searchModel.LifeCycleEventEndDate.Value.AddDays(1);
            query = query.Where(a => a.AssetsLifeCycleEvents.Any(alce => alce.DateTo < endDate));
        }

        searchModel.Results = await query
            .OrderBy(a => a.AssetName)
            .ToListAsync();
        searchModel.SearchPerformed = true;

        return View(searchModel);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var asset = await _context.Assets
            .Include(a => a.RefAssetType)
            .Include(a => a.RefSize)
            .Include(a => a.AssetsLifeCycleEvents)
                .ThenInclude(alce => alce.LifeCyclePhase)
            .Include(a => a.AssetsLifeCycleEvents)
                .ThenInclude(alce => alce.ResponsibleParty)
            .Include(a => a.AssetsLifeCycleEvents)
                .ThenInclude(alce => alce.Location)
            .FirstOrDefaultAsync(a => a.AssetId == id);

        if (asset is null)
        {
            return NotFound();
        }

        return View(asset);
    }
}

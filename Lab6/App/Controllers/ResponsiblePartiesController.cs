using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class ResponsiblePartiesController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var responsibleParties = await _context.ResponsibleParties
            .OrderBy(rp => rp.PartyDetails)
            .ToListAsync();
        return View(responsibleParties);
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var responsibleParty = await _context.ResponsibleParties
            .FirstOrDefaultAsync(rp => rp.PartyId == id);

        if (responsibleParty is null)
        {
            return NotFound();
        }

        var associatedAssets = await _context.AssetsLifeCycleEvents
            .Include(alce => alce.Asset)
            .Where(alce => alce.PartyId == id)
            .OrderByDescending(alce => alce.DateFrom)
            .Take(5)
            .ToListAsync();

        ViewData["AssociatedAssets"] = associatedAssets;

        return View(responsibleParty);
    }

}

using Microsoft.EntityFrameworkCore;

namespace App.Models;

public static class Seeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();

        if (context.Assets.Any())
        {
            return;
        }

        List<RefAssetCategory> assetCategories = new List<RefAssetCategory>
        {
            new RefAssetCategory { AssetCategoryCode = "ELECTRONICS", AssetCategoryDescription = "Electronic Items" },
            new RefAssetCategory { AssetCategoryCode = "FURNITURE", AssetCategoryDescription = "Furniture" },
            new RefAssetCategory { AssetCategoryCode = "VEHICLES", AssetCategoryDescription = "Vehicles" }
        };
        await context.RefAssetCategories.AddRangeAsync(assetCategories);
        await context.SaveChangesAsync();

        List<RefAssetSupertype> assetSupertypes = new List<RefAssetSupertype>
        {
            new RefAssetSupertype { AssetSupertypeCode = "COMPUTERS", AssetSupertypeDescription = "Computing Devices", AssetCategoryCode = "ELECTRONICS" },
            new RefAssetSupertype { AssetSupertypeCode = "OFFICE_FURNITURE", AssetSupertypeDescription = "Office Furniture", AssetCategoryCode = "FURNITURE" },
            new RefAssetSupertype { AssetSupertypeCode = "TRANSPORT", AssetSupertypeDescription = "Transport Vehicles", AssetCategoryCode = "VEHICLES" }
        };
        await context.RefAssetSupertypes.AddRangeAsync(assetSupertypes);
        await context.SaveChangesAsync();

        List<RefAssetType> assetTypes = new List<RefAssetType>
        {
            new RefAssetType { AssetTypeCode = "LAPTOP", AssetTypeDescription = "Laptop", AssetSupertypeCode = "COMPUTERS" },
            new RefAssetType { AssetTypeCode = "DESK", AssetTypeDescription = "Office Desk", AssetSupertypeCode = "OFFICE_FURNITURE" },
            new RefAssetType { AssetTypeCode = "VAN", AssetTypeDescription = "Delivery Van", AssetSupertypeCode = "TRANSPORT" }
        };
        await context.RefAssetTypes.AddRangeAsync(assetTypes);
        await context.SaveChangesAsync();

        List<RefSize> sizes = new List<RefSize>
        {
            new RefSize { SizeCode = "SMALL", SizeDescription = "Small" },
            new RefSize { SizeCode = "MEDIUM", SizeDescription = "Medium" },
            new RefSize { SizeCode = "LARGE", SizeDescription = "Large" }
        };
        await context.RefSizes.AddRangeAsync(sizes);
        await context.SaveChangesAsync();

        List<ResponsibleParty> responsibleParties = new List<ResponsibleParty>
        {
            new ResponsibleParty { PartyDetails = "TechCorp Electronics Repair" },
            new ResponsibleParty { PartyDetails = "Office Furniture Solutions" },
            new ResponsibleParty { PartyDetails = "FastTrack Delivery Services" }
        };
        await context.ResponsibleParties.AddRangeAsync(responsibleParties);
        await context.SaveChangesAsync();

        List<Location> locations = new List<Location>
        {
            new Location { LocationDetails = "Office Building 1" },
            new Location { LocationDetails = "Warehouse 2" },
            new Location { LocationDetails = "Delivery Center" }
        };
        await context.Locations.AddRangeAsync(locations);
        await context.SaveChangesAsync();

        List<LifeCyclePhase> lifeCyclePhases = new List<LifeCyclePhase>
        {
            new LifeCyclePhase { LifeCycleCode = "IN_USE", LifeCycleName = "In Use", LifeCycleDescription = "Asset is actively in use" },
            new LifeCyclePhase { LifeCycleCode = "MAINTENANCE", LifeCycleName = "Maintenance", LifeCycleDescription = "Asset is undergoing maintenance" },
            new LifeCyclePhase { LifeCycleCode = "DECOMMISSIONED", LifeCycleName = "Decommissioned", LifeCycleDescription = "Asset is no longer in use" }
        };
        await context.LifeCyclePhases.AddRangeAsync(lifeCyclePhases);
        await context.SaveChangesAsync();

        List<RefStatus> statuses = new List<RefStatus>
        {
            new RefStatus { StatusCode = "ACTIVE", StatusDescription = "Active" },
            new RefStatus { StatusCode = "INACTIVE", StatusDescription = "Inactive" },
            new RefStatus { StatusCode = "UNDER_REPAIR", StatusDescription = "Under Repair" }
        };
        await context.RefStatuses.AddRangeAsync(statuses);
        await context.SaveChangesAsync();

        List<Asset> assets = new List<Asset>
        {
            new Asset { AssetId = Guid.NewGuid(), AssetName = "Dell Laptop", AssetTypeCode = "LAPTOP", SizeCode = "MEDIUM", OtherDetails = "Model XPS 13" },
            new Asset { AssetId = Guid.NewGuid(), AssetName = "Office Desk", AssetTypeCode = "DESK", SizeCode = "LARGE", OtherDetails = "Wooden Desk" },
            new Asset { AssetId = Guid.NewGuid(), AssetName = "Ford Transit Van", AssetTypeCode = "VAN", SizeCode = "LARGE", OtherDetails = "Model 2020" }
        };
        await context.Assets.AddRangeAsync(assets);
        await context.SaveChangesAsync();

        List<AssetsLifeCycleEvent> lifeCycleEvents = new List<AssetsLifeCycleEvent>
        {
            new AssetsLifeCycleEvent
            {
                AssetId = assets[0].AssetId,
                LifeCycleCode = "IN_USE",
                LocationId = locations[0].LocationId,
                PartyId = responsibleParties[0].PartyId,
                StatusCode = "ACTIVE",
                DateFrom = DateTime.UtcNow.AddMonths(-6),
                DateTo = null 
            },
            new AssetsLifeCycleEvent
            {
                AssetId = assets[1].AssetId,
                LifeCycleCode = "IN_USE",
                LocationId = locations[0].LocationId,
                PartyId = responsibleParties[1].PartyId,
                StatusCode = "ACTIVE",
                DateFrom = DateTime.UtcNow.AddMonths(-3),
                DateTo = null 
            },
            new AssetsLifeCycleEvent
            {
                AssetId = assets[2].AssetId,
                LifeCycleCode = "IN_USE",
                LocationId = locations[1].LocationId,
                PartyId = responsibleParties[2].PartyId,
                StatusCode = "ACTIVE",
                DateFrom = DateTime.UtcNow.AddMonths(-1),
                DateTo = null 
            }
        };
        await context.AssetsLifeCycleEvents.AddRangeAsync(lifeCycleEvents);
        await context.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<RefAssetCategory> RefAssetCategories { get; set; } = default!;
    public DbSet<RefAssetSupertype> RefAssetSupertypes { get; set; } = default!;
    public DbSet<RefAssetType> RefAssetTypes { get; set; } = default!;
    public DbSet<Asset> Assets { get; set; } = default!;
    public DbSet<RefSize> RefSizes { get; set; } = default!;
    public DbSet<RefStatus> RefStatuses { get; set; } = default!;
    public DbSet<LifeCyclePhase> LifeCyclePhases { get; set; } = default!;
    public DbSet<Location> Locations { get; set; } = default!;
    public DbSet<ResponsibleParty> ResponsibleParties { get; set; } = default!;
    public DbSet<AssetsLifeCycleEvent> AssetsLifeCycleEvents { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.Entity<RefAssetCategory>()
            .HasKey(static rac => rac.AssetCategoryCode);

        _ = modelBuilder.Entity<RefAssetSupertype>()
            .HasKey(static ras => ras.AssetSupertypeCode);
        _ = modelBuilder.Entity<RefAssetSupertype>()
            .HasOne(static ras => ras.RefAssetCategory)
            .WithMany(static rac => rac.RefAssetSupertypes)
            .HasForeignKey(static ras => ras.AssetCategoryCode);

        _ = modelBuilder.Entity<RefAssetType>()
            .HasKey(static rat => rat.AssetTypeCode);
        _ = modelBuilder.Entity<RefAssetType>()
            .HasOne(static rat => rat.RefAssetSupertype)
            .WithMany(static ras => ras.RefAssetTypes)
            .HasForeignKey(static rat => rat.AssetSupertypeCode);

        _ = modelBuilder.Entity<Asset>()
            .HasKey(static a => a.AssetId);
        _ = modelBuilder.Entity<Asset>()
            .HasOne(static a => a.RefAssetType)
            .WithMany(static rat => rat.Assets)
            .HasForeignKey(static a => a.AssetTypeCode);
        _ = modelBuilder.Entity<Asset>()
            .HasOne(static a => a.RefSize)
            .WithMany(static rs => rs.Assets)
            .HasForeignKey(static a => a.SizeCode);

        _ = modelBuilder.Entity<RefSize>()
            .HasKey(static rs => rs.SizeCode);

        _ = modelBuilder.Entity<RefStatus>()
            .HasKey(static rs => rs.StatusCode);

        _ = modelBuilder.Entity<LifeCyclePhase>()
            .HasKey(static lcp => lcp.LifeCycleCode);

        _ = modelBuilder.Entity<Location>()
            .HasKey(static l => l.LocationId);

        _ = modelBuilder.Entity<ResponsibleParty>()
            .HasKey(static rp => rp.PartyId);

        _ = modelBuilder.Entity<AssetsLifeCycleEvent>()
            .HasKey(static alce => alce.AssetLifeCycleEventId);
        _ = modelBuilder.Entity<AssetsLifeCycleEvent>()
            .HasOne(static alce => alce.Asset)
            .WithMany(static a => a.AssetsLifeCycleEvents)
            .HasForeignKey(static alce => alce.AssetId);
        _ = modelBuilder.Entity<AssetsLifeCycleEvent>()
            .HasOne(static alce => alce.LifeCyclePhase)
            .WithMany(static lcp => lcp.AssetsLifeCycleEvents)
            .HasForeignKey(static alce => alce.LifeCycleCode);
        _ = modelBuilder.Entity<AssetsLifeCycleEvent>()
            .HasOne(static alce => alce.Location)
            .WithMany(static l => l.AssetsLifeCycleEvents)
            .HasForeignKey(static alce => alce.LocationId);
        _ = modelBuilder.Entity<AssetsLifeCycleEvent>()
            .HasOne(static alce => alce.ResponsibleParty)
            .WithMany(static rp => rp.AssetsLifeCycleEvents)
            .HasForeignKey(static alce => alce.PartyId);
        _ = modelBuilder.Entity<AssetsLifeCycleEvent>()
            .HasOne(static alce => alce.RefStatus)
            .WithMany(static rs => rs.AssetsLifeCycleEvents)
            .HasForeignKey(static alce => alce.StatusCode);
    }
}

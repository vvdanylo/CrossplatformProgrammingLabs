namespace App.Models;

public class AssetSearchViewModel
{
    public string? AssetName { get; set; }

    public string? AssetTypeCode { get; set; }

    public string? SizeCode { get; set; }

    public string? StatusCode { get; set; }

    public string? LocationDetails { get; set; }

    public string? ResponsiblePartyDetails { get; set; }

    public DateTime? LifeCycleEventStartDate { get; set; }

    public DateTime? LifeCycleEventEndDate { get; set; }

    public List<Asset> Results { get; set; } = new();

    public bool SearchPerformed { get; set; }
}

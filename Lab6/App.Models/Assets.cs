using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class Asset
{
    [Key]
    public Guid AssetId { get; set; }

    [MaxLength(15)]
    public string AssetTypeCode { get; set; }

    [ForeignKey(nameof(AssetTypeCode))]
    public RefAssetType RefAssetType { get; set; }

    [MaxLength(15)]
    public string SizeCode { get; set; }

    [ForeignKey(nameof(SizeCode))]
    public RefSize RefSize { get; set; }

    [MaxLength(255)]
    public string AssetName { get; set; }

    [MaxLength(255)]
    public string OtherDetails { get; set; }

    public ICollection<AssetsLifeCycleEvent> AssetsLifeCycleEvents { get; set; }
}


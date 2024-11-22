using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class RefAssetType
{
    [Key]
    [MaxLength(15)]
    public string AssetTypeCode { get; set; }

    [MaxLength(255)]
    public string AssetTypeDescription { get; set; }

    [MaxLength(15)]
    public string AssetSupertypeCode { get; set; }

    [ForeignKey(nameof(AssetSupertypeCode))]
    public RefAssetSupertype RefAssetSupertype { get; set; }

    public ICollection<Asset> Assets { get; set; }
}


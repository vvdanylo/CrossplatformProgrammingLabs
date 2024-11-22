using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class RefAssetSupertype
{
    [Key]
    [MaxLength(15)]
    public string AssetSupertypeCode { get; set; }

    [MaxLength(255)]
    public string AssetSupertypeDescription { get; set; }

    [MaxLength(15)]
    public string AssetCategoryCode { get; set; }

    [ForeignKey(nameof(AssetCategoryCode))]
    public RefAssetCategory RefAssetCategory { get; set; }

    public ICollection<RefAssetType> RefAssetTypes { get; set; }
}


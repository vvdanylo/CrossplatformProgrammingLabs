using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class RefAssetCategory
{
    [Key]
    [MaxLength(15)]
    public string AssetCategoryCode { get; set; }

    [MaxLength(255)]
    public string AssetCategoryDescription { get; set; }

    public ICollection<RefAssetSupertype> RefAssetSupertypes { get; set; }
}


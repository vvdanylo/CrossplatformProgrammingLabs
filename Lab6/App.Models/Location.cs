using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class Location
{
    [Key]
    public Guid LocationId { get; set; }

    [MaxLength(255)]
    public string LocationDetails { get; set; }

    public ICollection<AssetsLifeCycleEvent> AssetsLifeCycleEvents { get; set; }
}


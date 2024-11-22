using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class LifeCyclePhase
{
    [Key]
    [MaxLength(15)]
    public string LifeCycleCode { get; set; }

    [MaxLength(255)]
    public string LifeCycleName { get; set; }

    [MaxLength(255)]
    public string LifeCycleDescription { get; set; }

    public ICollection<AssetsLifeCycleEvent> AssetsLifeCycleEvents { get; set; }
}


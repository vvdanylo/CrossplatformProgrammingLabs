using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class RefStatus
{
    [Key]
    [MaxLength(15)]
    public string StatusCode { get; set; }

    [MaxLength(155)]
    public string StatusDescription { get; set; }

    public ICollection<AssetsLifeCycleEvent> AssetsLifeCycleEvents { get; set; }
}


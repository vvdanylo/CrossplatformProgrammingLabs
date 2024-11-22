using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class ResponsibleParty
{
    [Key]
    public Guid PartyId { get; set; }

    [MaxLength(255)]
    public string PartyDetails { get; set; }

    public ICollection<AssetsLifeCycleEvent> AssetsLifeCycleEvents { get; set; }
}


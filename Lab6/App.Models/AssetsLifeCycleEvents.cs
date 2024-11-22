using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class AssetsLifeCycleEvent
{
    [Key]
    public int AssetLifeCycleEventId { get; set; }

    public Guid AssetId { get; set; }
    [ForeignKey(nameof(AssetId))]
    public Asset Asset { get; set; }

    [MaxLength(15)]
    public string LifeCycleCode { get; set; }
    [ForeignKey(nameof(LifeCycleCode))]
    public LifeCyclePhase LifeCyclePhase { get; set; }

    public Guid LocationId { get; set; }
    [ForeignKey(nameof(LocationId))]
    public Location Location { get; set; }

    public Guid PartyId { get; set; }
    [ForeignKey(nameof(PartyId))]
    public ResponsibleParty ResponsibleParty { get; set; }

    [MaxLength(15)]
    public string StatusCode { get; set; }
    [ForeignKey(nameof(StatusCode))]
    public RefStatus RefStatus { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
}


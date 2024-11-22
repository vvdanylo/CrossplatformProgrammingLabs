using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models;

public class RefSize
{
    [Key]
    [MaxLength(15)]
    public string SizeCode { get; set; }

    [MaxLength(255)]
    public string SizeDescription { get; set; }

    public ICollection<Asset> Assets { get; set; }
}


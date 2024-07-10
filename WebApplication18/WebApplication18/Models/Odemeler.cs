using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication18.Models;

[Table("Odemeler")]
public partial class Odemeler
{
    [Key]
    [Column("OdemeID")]
    public int OdemeId { get; set; }

    [Column("RezervasyonID")]
    public int RezervasyonId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Miktar { get; set; }

    [StringLength(50)]
    public string OdemeYontemi { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime OdemeTarihi { get; set; }

    [ForeignKey("RezervasyonId")]
    [InverseProperty("Odemelers")]
    public virtual Rezervasyonlar Rezervasyon { get; set; } = null!;
}

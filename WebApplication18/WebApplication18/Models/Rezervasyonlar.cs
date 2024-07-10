using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication18.Models;

[Table("Rezervasyonlar")]
public partial class Rezervasyonlar
{
    [Key]
    [Column("RezervasyonID")]
    public int RezervasyonId { get; set; }

    [Column("KullaniciID")]
    public int KullaniciId { get; set; }

    [Column("ParkYeriID")]
    public int ParkYeriId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BaslangicZamani { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BitisZamani { get; set; }

    [StringLength(20)]
    public string Durum { get; set; } = null!;

    [ForeignKey("KullaniciId")]
    [InverseProperty("Rezervasyonlars")]
    public virtual Kullanicilar Kullanici { get; set; } = null!;

    [InverseProperty("Rezervasyon")]
    public virtual ICollection<Odemeler> Odemelers { get; set; } = new List<Odemeler>();

    [ForeignKey("ParkYeriId")]
    [InverseProperty("Rezervasyonlars")]
    public virtual ParkYerleri ParkYeri { get; set; } = null!;
}

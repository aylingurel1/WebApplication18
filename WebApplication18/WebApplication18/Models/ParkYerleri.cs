using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication18.Models;

[Table("ParkYerleri")]
public partial class ParkYerleri
{
    [Key]
    [Column("ParkYeriID")]
    public int ParkYeriId { get; set; }

    [StringLength(20)]
    public string ParkYeriNumarasi { get; set; } = null!;

    public bool DolulukDurumu { get; set; }

    [StringLength(100)]
    public string Konum { get; set; } = null!;

    [StringLength(50)]
    public string Tip { get; set; } = null!;

    [InverseProperty("ParkYeri")]
    public virtual ICollection<GirisCikisKayitlari> GirisCikisKayitlaris { get; set; } = new List<GirisCikisKayitlari>();

    [InverseProperty("ParkYeri")]
    public virtual ICollection<Rezervasyonlar> Rezervasyonlars { get; set; } = new List<Rezervasyonlar>();
}

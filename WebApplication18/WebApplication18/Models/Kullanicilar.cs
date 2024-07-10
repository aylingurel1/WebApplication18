using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication18.Models;

[Table("Kullanicilar")]
public partial class Kullanicilar
{
    [Key]
    [Column("KullaniciID")]
    public int KullaniciId { get; set; }

    [StringLength(50)]
    public string KullaniciAdi { get; set; } = null!;

    [StringLength(256)]
    public string SifreHash { get; set; } = null!;

    [StringLength(100)]
    public string Eposta { get; set; } = null!;

    [StringLength(20)]
    public string Rol { get; set; } = null!;

    [InverseProperty("Kullanici")]
    public virtual ICollection<Araclar> Araclars { get; set; } = new List<Araclar>();

    [InverseProperty("Kullanici")]
    public virtual ICollection<Rezervasyonlar> Rezervasyonlars { get; set; } = new List<Rezervasyonlar>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication18.Models;

[Table("Araclar")]
public partial class Araclar
{
    [Key]
    [Column("AracID")]
    public int AracId { get; set; }

    [Column("KullaniciID")]
    public int KullaniciId { get; set; }

    [StringLength(20)]
    public string Plaka { get; set; } = null!;

    [StringLength(50)]
    public string Marka { get; set; } = null!;

    [StringLength(50)]
    public string Model { get; set; } = null!;
    [NotMapped]
    [DisplayName("Upload Image File")]
    public IFormFile? ImageFile { get; set; }

    [StringLength(20)]
    public string Renk { get; set; } = null!;

    [InverseProperty("Arac")]
    public virtual ICollection<GirisCikisKayitlari> GirisCikisKayitlaris { get; set; } = new List<GirisCikisKayitlari>();

    [ForeignKey("KullaniciId")]
    [InverseProperty("Araclars")]
    public virtual Kullanicilar Kullanici { get; set; } = null!;
}

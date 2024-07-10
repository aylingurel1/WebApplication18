using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication18.Models;

[Table("GirisCikisKayitlari")]
public partial class GirisCikisKayitlari
{
    [Key]
    [Column("KayitID")]
    public int KayitId { get; set; }

    [Column("ParkYeriID")]
    public int ParkYeriId { get; set; }

    [Column("AracID")]
    public int AracId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime GirisZamani { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CikisZamani { get; set; }

    [ForeignKey("AracId")]
    [InverseProperty("GirisCikisKayitlaris")]
    public virtual Araclar Arac { get; set; } = null!;

    [ForeignKey("ParkYeriId")]
    [InverseProperty("GirisCikisKayitlaris")]
    public virtual ParkYerleri ParkYeri { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication18.Models;

[Table("Fiyatlandirma")]
public partial class Fiyatlandirma
{
    [Key]
    [Column("FiyatlandirmaID")]
    public int FiyatlandirmaId { get; set; }

    [StringLength(50)]
    public string ParkYeriTipi { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal SaatlikFiyat { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal GünlükFiyat { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal AylıkFiyat { get; set; }
}

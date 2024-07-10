using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication18.Models;

namespace WebApplication18.Models;

public partial class OtoparkUygulamasiContext : DbContext
{
   
    public OtoparkUygulamasiContext()
    {
    }

    public OtoparkUygulamasiContext(DbContextOptions<OtoparkUygulamasiContext> options)
        : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<WebApplication18.Models.Araclar> Araclar { get; set; } = default!;

public DbSet<WebApplication18.Models.Kullanicilar> Kullanicilar { get; set; } = default!;

public DbSet<WebApplication18.Models.Fiyatlandirma> Fiyatlandirma { get; set; } = default!;

public DbSet<WebApplication18.Models.Odemeler> Odemeler { get; set; } = default!;

public DbSet<WebApplication18.Models.ParkYerleri> ParkYerleri { get; set; } = default!;

public DbSet<WebApplication18.Models.Rezervasyonlar> Rezervasyonlar { get; set; } = default!;

public DbSet<WebApplication18.Models.GirisCikisKayitlari> GirisCikisKayitlari { get; set; } = default!;

public DbSet<WebApplication18.Models.Logincs> Logincs { get; set; } = default!;
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrimerParcial.EF;

public partial class MiDBContext : DbContext
{
    public MiDBContext(DbContextOptions<MiDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Titulare> Titulares { get; set; }

    public virtual DbSet<Tramite> Tramites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Titulare>(entity =>
        {
            entity.HasKey(e => e.IdTitulares).HasName("PRIMARY");

            entity.ToTable("titulares");

            entity.Property(e => e.IdTitulares).HasColumnName("idTitulares");
            entity.Property(e => e.FirstName).HasMaxLength(45);
            entity.Property(e => e.LastName).HasMaxLength(45);
            entity.Property(e => e.NumeroTramite).HasMaxLength(45);
        });

        modelBuilder.Entity<Tramite>(entity =>
        {
            entity.HasKey(e => e.IdTramite).HasName("PRIMARY");

            entity.ToTable("tramite");

            entity.Property(e => e.IdTramite).HasColumnName("idTramite");
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

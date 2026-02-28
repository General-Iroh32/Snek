using Microsoft.EntityFrameworkCore;
using Snek.Core.Models;

namespace Snek.Infrastructure.Persistence;

public sealed class SnekDbContext(DbContextOptions<SnekDbContext> options) : DbContext(options)
{
    public DbSet<Mitwirkende> Mitwirkende => Set<Mitwirkende>();

    public DbSet<Arbeiten> Arbeiten => Set<Arbeiten>();

    public DbSet<Zeiten> Zeiten => Set<Zeiten>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mitwirkende>(entity =>
        {
            entity.Property(item => item.Vorname).HasMaxLength(100).IsRequired();
            entity.Property(item => item.Nachname).HasMaxLength(100).IsRequired();
            entity.Ignore(item => item.VollerName);
        });

        modelBuilder.Entity<Arbeiten>(entity =>
        {
            entity.Property(item => item.Art).HasMaxLength(100).IsRequired();
            entity.HasMany(item => item.Mitwirkende)
                .WithMany(item => item.Arbeiten)
                .UsingEntity("ArbeitenMitwirkende");
        });

        modelBuilder.Entity<Zeiten>(entity =>
        {
            entity.Ignore(item => item.Dauer);
            entity.HasOne(item => item.Arbeiten)
                .WithMany(item => item.Zeiten)
                .HasForeignKey(item => item.ArbeitenId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.ToTable(table =>
            {
                table.HasCheckConstraint("CK_Zeiten_Stunden", "Stunden >= 0");
                table.HasCheckConstraint("CK_Zeiten_Minuten", "Minuten >= 0 AND Minuten < 60");
                table.HasCheckConstraint("CK_Zeiten_Sekunden", "Sekunden >= 0 AND Sekunden < 60");
            });
        });
    }
}

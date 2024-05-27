using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Watch> Watches { get; set; }
    public DbSet<Dial> Brand { get; set; }
    public DbSet<Calibre> Calibres { get; set; }
    public DbSet<Case> Cases { get; set; }
    public DbSet<CaseMaterial> CaseMaterials { get; set; }
    public DbSet<Crystal> Crystals { get; set; }
    public DbSet<Dial> Dials { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    public DbSet<PowerReserve> PowerReserves { get; set; }
    public DbSet<StrapBraceletMaterial> StrapBraceletMaterials { get; set; }
    public DbSet<WatchType> WatchTypes { get; set; }
    public DbSet<WaterResistance> WaterResistances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>()
            .HasIndex(b => b.Name)
            .IsUnique();
        
        modelBuilder.Entity<Calibre>()
            .HasIndex(c => c.Name)
            .IsUnique();
        
        modelBuilder.Entity<CaseMaterial>()
            .HasIndex(c => c.Material)
            .IsUnique();
        
        modelBuilder.Entity<Crystal>()
            .HasIndex(c => c.Material)
            .IsUnique();

        modelBuilder.Entity<Dial>()
            .HasIndex(d => d.Colour)
            .IsUnique();
        
        modelBuilder.Entity<MovementType>()
            .HasIndex(m => m.Type)
            .IsUnique();
        
        modelBuilder.Entity<PowerReserve>()
            .HasIndex(p => p.Duration)
            .IsUnique();
        
        modelBuilder.Entity<StrapBraceletMaterial>()
            .HasIndex(s => s.Material)
            .IsUnique();
        
        modelBuilder.Entity<WatchType>()
            .HasIndex(w => w.Type)
            .IsUnique();
        
        modelBuilder.Entity<WaterResistance>()
            .HasIndex(w => w.Resistance)
            .IsUnique();
    }
}
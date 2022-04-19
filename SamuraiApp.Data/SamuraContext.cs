using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;


namespace SamuraiApp.Data;

public class SamuraContext : DbContext
{
    public SamuraContext()
    {

    }
    public SamuraContext(DbContextOptions<SamuraContext> options):base(options)
    {
        
    }
    public DbSet<Samurai>? Samurais { get; set; }
    public DbSet<Quote>? Quotes { get; set; }
    public DbSet<Battle>? Battles { get; set; }
    public DbSet<Katana>? Katanas { get; set; }
    public DbSet<Elemen>? Elemens { get; set; } 
    public DbSet<SamuraiBattleStat>? SamuraiBattlesStats { get; set; }
    public DbSet<ElemenKatana> ElemenKatanas { get; set; } 
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder){
        //if (!optionBuilder.IsConfigured)
        //{
        //    optionBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SamuraiTestDB");
        //    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},
        //    Microsoft.Extensions.Logging.LogLevel.Information)
        //    .EnableSensitiveDataLogging();
        //}
        if (!optionBuilder.IsConfigured)
        {
            optionBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=SamuraiDB");
        }

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Samurai>()
                .HasMany(a => a.Battles)
                .WithMany(b => b.Samurais)
            .UsingEntity<BattleSamurai>(
                bs =>  bs.HasOne<Battle>().WithMany(),
                bs => bs.HasOne<Samurai>().WithMany())
            .Property(bs => bs.DateJoined)
            .HasDefaultValueSql("getdate()");
        modelBuilder.Entity<Katana>()
                .HasMany(a => a.Elemens)
                .WithMany(b => b.Katanas)
            .UsingEntity<ElemenKatana>(
                bs => bs.HasOne<Elemen>().WithMany(),
                bs => bs.HasOne<Katana>().WithMany());
        modelBuilder.Entity<ElemenKatana>()
            .HasKey(ek => new { ek.ElemenId, ek.KatanaId });
        modelBuilder.Entity<Horse>().ToTable("Horses");
        modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");//NoTracking by Default
    }
}

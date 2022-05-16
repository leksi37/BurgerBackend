namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

public class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } 
    
    public DbSet<BurgerPlace> BurgerPlaces { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Burger> Burgers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    
    private readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Review>()
    //        .HasOne<Burger>()
    //        .WithMany()
    //        .HasForeignKey(p => p.BurgerId);

    //    modelBuilder.Entity<Burger>()
    //        .HasOne<BurgerPlace>()
    //        .WithMany()
    //        .HasForeignKey(p => p.BurgerPlaceId);

    //    modelBuilder.Entity<Burger>()
    //        .HasOne<Score>()
    //        .WithOne()
    //        .HasForeignKey<Score>();
    //}
}
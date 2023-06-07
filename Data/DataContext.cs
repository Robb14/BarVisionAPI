using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlServer("A FALLBACK CONNECTION STRING");
        }
    }

    // Definimos las DbSet para cada una de tus entidades
    public DbSet<UserModel> Users { get; set; }
    public DbSet<BarModel> Bars { get; set; }
    public DbSet<ReservationModel> Reservations { get; set; }
    public DbSet<ReviewModel> Reviews { get; set; }
    public DbSet<MatchModel> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MatchModel>()
            .HasOne(m => m.Bar)
            .WithMany(b => b.Matches)
            .HasForeignKey(m => m.BarId);
    }

}

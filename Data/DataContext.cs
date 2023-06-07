using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    // Definimos las DbSet para cada una de tus entidades
    public DbSet<UserModel> Users { get; set; }
    public DbSet<BarModel> Bars { get; set; }
    public DbSet<ReservationModel> Reservations { get; set; }
    public DbSet<ReviewModel> Reviews { get; set; }
    public DbSet<MatchModel> Matches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}

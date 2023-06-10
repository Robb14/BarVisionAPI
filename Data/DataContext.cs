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

        modelBuilder.Entity<ReservationModel>()
        .HasOne(r => r.Bar)
        .WithMany(b => b.Reservations)
        .HasForeignKey(r => r.BarId)
        .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ReservationModel>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);

       modelBuilder.Entity<ReviewModel>()
        .HasOne(r => r.User)
        .WithMany(u => u.Reviews)
        .HasForeignKey(r => r.UserId)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired(); // Agrega IsRequired() para asegurar que la relación sea obligatoria

    modelBuilder.Entity<ReviewModel>()
        .HasOne(r => r.Bar)
        .WithMany(b => b.Reviews)
        .HasForeignKey(r => r.BarId)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired(); // Agrega IsRequired() para asegurar que la relación sea obligatoria


        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
    .SelectMany(t => t.GetForeignKeys())
    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        base.OnModelCreating(modelBuilder);
    }

}

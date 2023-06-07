public class SampleData
{
    public static void InitializeData(MyDbContext dbContext)
    {
        // Crea el usuario admin
        var admin = new UserModel
        {
            Username = "rober",
            Password = "020202",
            Email = "admin@example.com",
            UserType = UserType.Admin
        };

        // Crea los owners y sus bares
        var owner1 = new UserModel
        {
            Username = "owner1",
            Password = "password1",
            Email = "owner1@example.com",
            UserType = UserType.Owner
        };

        var bar1 = new BarModel
        {
            Name = "Bar 1",
            Location = "Ubicación del Bar 1",
            Match = "Partido del Bar 1",
            OwnerId = owner1.Id
        };

        var owner2 = new UserModel
        {
            Username = "owner2",
            Password = "password2",
            Email = "owner2@example.com",
            UserType = UserType.Owner
        };

        var bar2 = new BarModel
        {
            Name = "Bar 2",
            Location = "Ubicación del Bar 2",
            Match = "Partido del Bar 2",
            OwnerId = owner2.Id
        };

        // Crea los usuarios normales y sus reservas
        var user1 = new UserModel
        {
            Username = "user1",
            Password = "password1",
            Email = "user1@example.com",
            UserType = UserType.User
        };

        var reservation1 = new ReservationModel
        {
            UserId = user1.Id,
            BarId = bar1.Id,
            Date = DateTime.Now.AddDays(1),
            AmountOfPeople = 2
        };

        var user2 = new UserModel
        {
            Username = "user2",
            Password = "password2",
            Email = "user2@example.com",
            UserType = UserType.User
        };

        var reservation2 = new ReservationModel
        {
            UserId = user2.Id,
            BarId = bar2.Id,
            Date = DateTime.Now.AddDays(2),
            AmountOfPeople = 3
        };

        var user3 = new UserModel
        {
            Username = "user3",
            Password = "password3",
            Email = "user3@example.com",
            UserType = UserType.User
        };

        var reservation3 = new ReservationModel
        {
            UserId = user3.Id,
            BarId = bar1.Id,
            Date = DateTime.Now.AddDays(3),
            AmountOfPeople = 4
        };

        var user4 = new UserModel
        {
            Username = "user4",
            Password = "password4",
            Email = "user4@example.com",
            UserType = UserType.User
        };

        var reservation4 = new ReservationModel
        {
            UserId = user4.Id,
            BarId = bar2.Id,
            Date = DateTime.Now.AddDays(4),
            AmountOfPeople = 5
        };

        // Agrega los datos al contexto
        dbContext.Users.AddRange(admin, owner1, owner2, user1, user2, user3, user4);
        dbContext.Bars.AddRange(bar1, bar2);
        dbContext.Reservations.AddRange(reservation1, reservation2, reservation3, reservation4);

        // Guarda los cambios en la base de datos
        dbContext.SaveChanges();
    }
}

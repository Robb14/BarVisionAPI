public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public List<Reservation> Reservations { get; set; }
    
    public const string NormalUserRole = "NormalUser";
    public const string AdminRole = "Admin";
    public const string SuperAdminRole = "SuperAdmin";
}

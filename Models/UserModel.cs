public enum UserType
{
    Normal,
    Owner,
    Admin
}


public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string UserType { get; set; }
    public bool IsActive { get; set; }

    // Relación uno a muchos con ReservationModel
    public List<ReservationModel> Reservations { get; set; }

    // Relación uno a muchos con ReviewModel
    public List<ReviewModel> Reviews { get; set; }
}

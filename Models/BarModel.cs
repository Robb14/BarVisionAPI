public class BarModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Match { get; set; }
    public int OwnerId { get; set; }
    public bool IsActive { get; set; }

    // Relación muchos a uno con UserModel (Propietario)
    public UserModel Owner { get; set; }

    // Relación uno a muchos con ReservationModel
    public List<ReservationModel> Reservations { get; set; }

    // Relación uno a muchos con ReviewModel
    public List<ReviewModel> Reviews { get; set; }

    public string Menu { get; set; }

    public List<string> Images { get; set; }
}

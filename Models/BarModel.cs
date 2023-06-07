public class BarModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Match { get; set; }
    public int OwnerId { get; set; }
    public bool IsActive { get; set; }
    public string Menu { get; set; }

    // Relación muchos a uno con UserModel (Propietario)
    public UserModel Owner { get; set; }

    // Relación uno a muchos con ReservationModel
    public List<ReservationModel> Reservations { get; set; }

    // Relación uno a muchos con ReviewModel
    public List<ReviewModel> Reviews { get; set; }

    // Relación uno a muchos con ImageModel
    public List<ImageModel> Images { get; set; }
}

public class ImageModel
{
    public int Id { get; set; }
    public string Url { get; set; }

    // Propiedad de navegación a BarModel
    public int BarId { get; set; }
    public BarModel Bar { get; set; }
}

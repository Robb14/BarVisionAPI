public class ReservationModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int BarId { get; set; }
    public int UserId { get; set; }
    public int AmountOfPeople { get; set; } // Nueva propiedad para la cantidad de personas

    // Relación muchos a uno con BarModel
    public BarModel Bar { get; set; }

    // Relación muchos a uno con UserModel
    public UserModel User { get; set; }
}

public class Reservation
{
    public int Id { get; set; }
    public int BarId { get; set; }
    public Bar Bar { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime ReservationDate { get; set; }
    public int NumberOfPeople { get; set; }
}

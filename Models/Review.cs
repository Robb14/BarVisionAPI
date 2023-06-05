public class Review
{
    public int Id { get; set; }
    public int BarId { get; set; }
    public Bar Bar { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime Fecha { get; set; }
}

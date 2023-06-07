public class ReviewModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BarId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
    public DateTime DateTime { get; set; }

    // Relación muchos a uno con UserModel
    public UserModel User { get; set; }

    // Relación muchos a uno con BarModel
    public BarModel Bar { get; set; }
}

public class MatchModel
{
    public int Id { get; set; }
    public string? Sport { get; set; }
    public DateTime Date { get; set; }
    public int BarId { get; set; } // Foreign Key

    // Relación muchos a uno con BarModel
    public BarModel? Bar { get; set; }
}


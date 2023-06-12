using System.Text.Json.Serialization;

public class MatchModel
{
    public int Id { get; set; }
    public string? Sport { get; set; }
    public DateTime Date { get; set; }
    public int BarId { get; set; } // Foreign Key

    // Relación muchos a uno con BarModel
    [JsonIgnore]
    public BarModel? Bar { get; set; }
}


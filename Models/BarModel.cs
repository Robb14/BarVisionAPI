using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class BarModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Match { get; set; }
    public bool IsActive { get; set; }
    public string? Menu { get; set; }

    [JsonIgnore]
    public List<MatchModel>? Matches { get; set; }

    // Relación muchos a uno con UserModel (Propietario)
    [ForeignKey("Owner")]
    public int OwnerId { get; set; }
    [JsonIgnore]
    public UserModel? Owner { get; set; }

    // Relación uno a muchos con ReservationModel
    [JsonIgnore]
    public List<ReservationModel>? Reservations { get; set; }

    // Relación uno a muchos con ReviewModel
    [JsonIgnore]
    public List<ReviewModel>? Reviews { get; set; }

    // Relación uno a muchos con ImageModel
    [JsonIgnore]
    public List<ImageModel>? Images { get; set; }
}


public class ImageModel
{
    public int Id { get; set; }
    public string? Url { get; set; }

    // Propiedad de navegación a BarModel
    public int BarId { get; set; }
    [JsonIgnore]
    public BarModel? Bar { get; set; }
}

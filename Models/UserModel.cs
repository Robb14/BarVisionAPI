using System.Text.Json.Serialization;

public enum UserType
{
    Normal = 0,
    Owner = 1,
    Admin = 2
}


public class UserModel
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserType UserType { get; set; }
    public bool IsActive { get; set; }

    // Relación uno a muchos con ReservationModel
    [JsonIgnore]
    public List<ReservationModel>? Reservations { get; set; }

    // Relación uno a muchos con ReviewModel
    [JsonIgnore]
    public List<ReviewModel>? Reviews { get; set; }
}


public class Bar
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string Match { get; set; }
    public List<Image> Images { get; set; }
    public string AdminId { get; set; }
    public User Admin { get; set; }
    public List<MenuItem> MenuItems { get; set; }
    public List<Review> Reviews { get; set; }
    public List<Reservation> Reservations { get; set; }
}

public class Image
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int BarId { get; set; }
    public Bar Bar { get; set; }
}

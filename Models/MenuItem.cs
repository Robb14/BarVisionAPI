public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string FirstCourse { get; set; }
    public string SecondCourse { get; set; }
    public string Dessert { get; set; }
    public int BarId { get; set; }
    public Bar Bar { get; set; }
}

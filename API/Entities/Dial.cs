namespace API.Entities;

public class Dial
{
    public int Id { get; set; }
    public string Colour { get; set; }
    public List<Watch> Watches { get; set; } = new();
}
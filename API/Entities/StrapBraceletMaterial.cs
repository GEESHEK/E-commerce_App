namespace API.Entities;

public class StrapBraceletMaterial
{
    public int Id { get; set; }
    public string Material { get; set; }
    public List<Watch> Watches { get; set; } = new();
}
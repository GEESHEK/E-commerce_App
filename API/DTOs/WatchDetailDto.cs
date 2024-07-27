using API.Entities;

namespace API.DTOs;

public class WatchDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Calibre { get; set; }
    public string CaseMaterial { get; set; }
    public string Crystal { get; set; }
    public string Dial { get; set; }
    public bool Lume { get; set; }
    public string Reference { get; set; }
    public string MovementType { get; set; }
    public decimal Price { get; set; }
    public int PowerReserve { get; set; }
    public string Stock { get; set; }
    public string StrapBraceletMaterial { get; set; }
    public double Diameter { get; set; }
    public double Thickness { get; set; }
    public double Length { get; set; }
    public double LugWidth { get; set; }
    public string WatchType { get; set; }
    public int WaterResistance { get; set; }
    public string OtherSpecifications { get; set; }
    public List<Photo> Photos { get; set; } = new();
}
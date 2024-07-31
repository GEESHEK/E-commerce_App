using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class WatchUpdateDto
{
    public string Name { get; set; }
    public int BrandId { get; set; }
    public int CalibreId { get; set; }
    public int CaseMaterialId { get; set; }
    public int CrystalId { get; set; }
    public string Description { get; set; }
    public int DialId { get; set; }
    public bool Lume { get; set; }
    public string Reference { get; set; }
    public int MovementTypeId { get; set; }
    public decimal Price { get; set; }
    public int PowerReserveId { get; set; }
    public int Stock { get; set; }
    public int StrapBraceletMaterialId { get; set; }
    public int WatchCaseMeasurementsId { get; set; }
    public int WatchTypeId { get; set; }
    public int WaterResistanceId { get; set; }
    public string OtherSpecifications { get; set; }
    public decimal Cost { get; set; }
}
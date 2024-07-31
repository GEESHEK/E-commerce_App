using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace API.Entities;

[ExcludeFromCodeCoverage]
public class Watch
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    [JsonIgnore]
    public int CalibreId { get; set; }
    public Calibre Calibre { get; set; }
    [JsonIgnore]
    public int CaseMaterialId { get; set; }
    public CaseMaterial CaseMaterial { get; set; }
    [JsonIgnore]
    public int CrystalId { get; set; }
    public Crystal Crystal { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public int DialId { get; set; }

    public Dial Dial { get; set; }
    public bool Lume { get; set; }
    public string Reference { get; set; }
    [JsonIgnore]
    public int MovementTypeId { get; set; }
    public MovementType MovementType { get; set; }
    public decimal Price { get; set; }
    [JsonIgnore]
    public int PowerReserveId { get; set; }
    public PowerReserve PowerReserve { get; set; }
    public Stock Stock { get; set; }
    [JsonIgnore]
    public int StrapBraceletMaterialId { get; set; }
    public StrapBraceletMaterial StrapBraceletMaterial { get; set; }
    [JsonIgnore]
    public int WatchCaseMeasurementsId { get; set; }
    public WatchCaseMeasurements WatchCaseMeasurements { get; set; }
    [JsonIgnore]
    public int WatchTypeId { get; set; }
    public WatchType WatchType { get; set; }
    [JsonIgnore]
    public int WaterResistanceId { get; set; }
    public WaterResistance WaterResistance { get; set; }
    public string OtherSpecifications { get; set; }
    [JsonIgnore]
    public decimal Cost { get; set; }

    public DateOnly DateAdded { get; set; } = DateOnly.FromDateTime(DateTime.Today);

    public List<Photo> Photos { get; set; } = new();
}
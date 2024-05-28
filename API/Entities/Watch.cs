namespace API.Entities;

public class Watch
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
    public int CalibreId { get; set; }
    public Calibre Calibre { get; set; }
    public int CaseMaterialId { get; set; }
    public CaseMaterial CaseMaterial { get; set; }
    public int CrystalId { get; set; }
    public Crystal Crystal { get; set; }
    public int DialId { get; set; }
    public Dial Dial { get; set; }
    public bool Lume { get; set; }
    public string Reference { get; set; }
    public int MovementTypeId { get; set; }
    public MovementType MovementType { get; set; }
    public Decimal Price { get; set; }
    public int PowerReserveId { get; set; }
    public PowerReserve PowerReserve { get; set; }
    public int Quantity { get; set; }
    public int StrapBraceletMaterialId { get; set; }
    public StrapBraceletMaterial StrapBraceletMaterial { get; set; }
    public int WatchCaseMeasurementsId { get; set; }
    public WatchCaseMeasurements WatchCaseMeasurementsType { get; set; }
    public int WatchTypeId { get; set; }
    public WatchType WatchType { get; set; }
    public int WaterResistanceId { get; set; }
    public WaterResistance WaterResistance { get; set; }
    public string OtherSpecifications { get; set; }
}
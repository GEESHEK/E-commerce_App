namespace API.Entities;

public class Case
{
    public int Id { get; set; }
    public Dial Dial { get; set; }
    public Crystal Crystal { get; set; }
    public bool Lume { get; set; } = false;
    public CaseMaterial CaseMaterial { get; set; }
    public StrapBraceletMaterial StrapBraceletMaterial { get; set; }
    public WatchCaseMeasurements WatchCaseMeasurements { get; set; }
    public WaterResistance WaterResistance { get; set; }
}
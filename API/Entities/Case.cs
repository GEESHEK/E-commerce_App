namespace API.Entities;

public class Case
{
    public Dial Dial { get; set; }
    public Crystal Crystal { get; set; }
    public bool Lume { get; set; }
    public Material CaseMaterial { get; set; }
    public Material StrapBracelet { get; set; }
    public WatchCaseMeasurements WatchCaseMeasurements { get; set; }
    public WaterResistance WaterResistance { get; set; }
}
namespace API.DTOs.WatchDTOs;

public class WatchFilterDto
{
    public List<string> Brands { get; set; }
    public List<string> Calibres { get; set; }
    public List<string> Dials { get; set; }
    public List<string> MovementTypes { get; set; }
    public List<string> WatchTypes { get; set; }
    public List<double> Diameters { get; set; }
}
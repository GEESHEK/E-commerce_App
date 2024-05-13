namespace API.Entities;

public class Watch
{
    public int Id { get; set; }
    public string Brand { get; set; } //reference table
    public string Model { get; set; }
    public string Reference { get; set; }
    //Todo
    //Movement reference table 
    //other features to be added as well
}

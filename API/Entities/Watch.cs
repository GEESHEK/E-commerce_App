namespace API.Entities;

public class Watch
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Brand Brand { get; set; }
    public Case Case { get; set; }
    public string Reference { get; set; }
    public MovementType MovementType { get; set; }
    public Decimal Price { get; set; }
    public int Quantity { get; set; }
    public WatchType WatchType { get; set; }
    public string OtherSpecifications { get; set; }
}
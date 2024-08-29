namespace API.Entities;

public class Item
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ItemType ItemType { get; set; }
    public string Quantity { get; set; }
    public Order Order { get; set; }
}
namespace API.DTOs;

public class CartWatchDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Name { get; set; }
    public string Reference { get; set; }
    public decimal Price { get; set; }
    public string Stock { get; set; }
    public string PhotoUrl { get; set; }
}
namespace API.DTOs.OrderDTOs;

public class SuccessOrderDto
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public CustomerDetailDto CustomerDetail { get; set; }
    public string StatusType { get; set; }
    public decimal Total { get; set; }
    public List<ItemDto> Items { get; set; } = new();
}
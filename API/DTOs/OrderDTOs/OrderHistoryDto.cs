namespace API.DTOs.OrderDTOs;

public class OrderHistoryDto
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string StatusType { get; set; }
}
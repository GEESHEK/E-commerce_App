namespace API.DTOs.OrderDTOs;

public class UserOrderDetailDto
{
    public int Id { get; set; }
    public DateTime OrderDateTime { get; set; }
    public string StatusType { get; set; }
    public string Url { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.OrderDTOs;

public class ItemDto
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int ItemTypeId { get; set; }
    [Required]
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
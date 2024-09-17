using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class ItemDto
{
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int ItemTypeId { get; set; }
    [Required]
    public int Quantity { get; set; }
}
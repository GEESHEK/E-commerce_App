using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class Brand
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Watch> Watches { get; set; } = new();
}
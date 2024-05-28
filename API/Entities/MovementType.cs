using Microsoft.EntityFrameworkCore;

namespace API.Entities;

public class MovementType
{
    public int Id { get; set; }
    public string Type { get; set; }
    public List<Watch> Watches { get; set; } = new();
}
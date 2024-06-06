using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs;

public class AddWatchDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public Brand Brand { get; set; }
    [Required]
    public Calibre Calibre { get; set; }
    [Required]
    public CaseMaterial CaseMaterial { get; set; }
    [Required]
    public Crystal Crystal { get; set; }
    [Required]
    public Dial Dial { get; set; }
    [Required]
    public bool Lume { get; set; }
    [Required]
    public string Reference { get; set; }
    [Required]
    public MovementType MovementType { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public PowerReserve PowerReserve { get; set; }
    [Required]
    public Stock Stock { get; set; }
    [Required]
    public StrapBraceletMaterial StrapBraceletMaterial { get; set; }
    [Required]
    public WatchCaseMeasurements WatchCaseMeasurements { get; set; }
    [Required]
    public WatchType WatchType { get; set; }
    [Required]
    public WaterResistance WaterResistance { get; set; }
    [Required]
    public string OtherSpecifications { get; set; }
    [Required]
    public decimal Cost { get; set; }
    [Required]
    public List<Photo> Photos { get; set; } = new();
}
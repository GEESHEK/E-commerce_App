using System.ComponentModel.DataAnnotations;
using API.Entities;

namespace API.DTOs;

public class CreateWatchDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int BrandId { get; set; }
    [Required]
    public int CalibreId { get; set; }
    [Required]
    public int CaseMaterialId { get; set; }
    [Required]
    public int CrystalId { get; set; }
    [Required]
    public int DialId { get; set; }
    [Required]
    public bool Lume { get; set; }
    [Required]
    public string Reference { get; set; }
    [Required]
    public int MovementTypeId { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int PowerReserveId { get; set; }
    [Required]
    public int Stock { get; set; } //come back to mapping this
    [Required]
    public int StrapBraceletMaterialId { get; set; }
    [Required]
    public int WatchCaseMeasurementsId { get; set; }
    [Required]
    public int WatchTypeId { get; set; }
    [Required]
    public int WaterResistanceId { get; set; }
    public string OtherSpecifications { get; set; }
    [Required]
    public decimal Cost { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.UserDTOs;

public class UserProfileDto
{
    [Required] 
    public int CustomerDetailId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string ZipCode { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Country { get; set; }
}
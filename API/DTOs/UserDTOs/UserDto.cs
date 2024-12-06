using System.ComponentModel.DataAnnotations;

namespace API.DTOs.UserDTOs;

public class UserDto
{
    [Required]
    public required string Username { get; set; }
    [Required] 
    public required string Token { get; set; }
}
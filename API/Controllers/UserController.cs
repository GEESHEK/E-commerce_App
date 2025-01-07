using API.Data.Repositories;
using API.Entities.UserEntities;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        
        return Ok(users);
    }

    [Authorize]
    [HttpGet("profile")]
    public async Task<ActionResult<AppUser>> GetUser()
    {
        try
        {
            var userId = User.GetUserId();
            
            var user = await _userRepository.GetUserById(userId);
        
            if (user == null) return NotFound("User not found");
            
            return Ok(user);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}
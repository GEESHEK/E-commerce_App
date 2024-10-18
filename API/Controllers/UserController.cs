using API.Data.Repositories;
using API.Entities.UserEntities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet]
    public Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return null;
    }
    
}
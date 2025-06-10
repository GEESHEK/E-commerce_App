using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AdminController : BaseApiController
{
    [Authorize(Policy = "RequireAdminRole")]
    [HttpGet]
    public ActionResult GetUsersWithRoles()
    {
        return Ok("Only admins can see this");
    }
}
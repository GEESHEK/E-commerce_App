using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities.UserEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly DataContext _context;

    public AccountController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
        
        //If we don't use using, garbage collector will at some point dispose of it
        //Using will depose of it as soon as we stop using it
        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            Username = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key,
            Gender = registerDto.Gender, //change to enum
        };

        _context.AppUsers.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
    {
        var user = await _context.AppUsers.FirstOrDefaultAsync(x => 
            x.Username == loginDto.Username.ToLower());
        
        if (user == null) return Unauthorized("Invalid username");
        
        using var hmac = new HMACSHA512(user.PasswordSalt);
        
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        }
        
        return user;
    }

    private async Task<bool> UserExists(string username)
    {
        return await _context.AppUsers.AnyAsync(x => x.Username.ToLower() == username.ToLower());
    }
}
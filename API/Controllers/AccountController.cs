using System.Security.Cryptography;
using System.Text;
using API.Data.Repositories;
using API.DTOs.UserDTOs;
using API.Entities.UserEntities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITokenService _tokenService;

    public AccountController(IAccountRepository accountRepository, ITokenService tokenService)
    {
        _accountRepository = accountRepository;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await _accountRepository.UserExists(registerDto.Username)) return BadRequest("Username is taken");

        if (registerDto.Gender != 0 && registerDto.Gender != 1)
            return BadRequest("Invalid Gender value. Must be 0 (Male) or 1 (Female)");
        
        //If we don't use using, garbage collector will at some point dispose of it
        //Using will depose of it as soon as we stop using it
        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            UserName = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key,
            Gender = registerDto.Gender == 0 ? Gender.Male : Gender.Female
        };

        _accountRepository.AddUser(user);
        await _accountRepository.SaveAllAsync();

        return new UserDto
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _accountRepository.UserExists(loginDto);
        
        if (user == null) return Unauthorized("Invalid username");
        
        using var hmac = new HMACSHA512(user.PasswordSalt);
        
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        }
        
        return new UserDto
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }
}
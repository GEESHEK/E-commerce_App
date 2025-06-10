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

        var user = new AppUser
        {
            UserName = registerDto.Username,
            Gender = registerDto.Gender == 0 ? Gender.Male : Gender.Female
        };

        var result = await _accountRepository.AddUser(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

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

        if (user == null || user.UserName == null) return Unauthorized("Invalid username");

        var result = await _accountRepository.CheckPassword(user, loginDto.Password);

        if (!result) return Unauthorized("Invalid password");

        return new UserDto
        {
            Username = user.UserName,
            Token = _tokenService.CreateToken(user)
        };
    }
}
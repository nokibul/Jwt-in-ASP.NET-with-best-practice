using System;
using Microsoft.AspNetCore.Mvc;
using Agency.Models.MyContext;
using Agency.Models.DTOs;
using Agency.Interfaces;
// using Agency.Services.Authentication.User;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    public readonly MyContext _context;
    public readonly IUserService _userService;
    public readonly IJwtService _jwtService;

    public AuthenticationController(MyContext context, IUserService userService, IJwtService _jwtService)
    {
        _context = context;
        _userService = userService;
        _jwtService = jwtService;
    }

    // register
    [HttpPost("register")]
    public async Task<ActionResult<UserDataDTO>> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // register the user using service
        UserDataDTO userData = await _userService.RegisterUser(userRegistrationDTO);
        // return the registered user detail data

        return Ok(userData);
    }

    [HttpPost]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
    {
        // identify if the user exists or not

        //generate jwt token 
        string jwtToken = _jwtService.GenerateToken()
        // return it 
        return Ok(sampleResponse);
    }

}
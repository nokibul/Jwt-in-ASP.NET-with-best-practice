using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Agency.Data.MyContext;
using Agency.Authentication.DTOs;
using Agency.Authentication.Interfaces;
using Agency.Member.Interfaces;
using Agency.Member.Repositories;
using Agency.Member.Entities;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{

    public readonly IUserRepository _userRepository;
    public readonly IUserService _userService;
    public readonly IJwtService _jwtService;
    private readonly IMapper _mapper;
    public AuthenticationController(IUserService userService, IJwtService jwtService, IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _userService = userService;
        _jwtService = jwtService;
        _mapper = mapper;
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
        MemberEntity user = await _userRepository.GetUserByEmail(userLoginDTO.Email);

        if (user == null)
        {
            return NotFound($"User with email '{userLoginDTO.Email}' not found.");
        }

        var userData = _mapper.Map<UserDataDTO>(user);
        //generate jwt token 
        string jwtToken = _jwtService.GenerateToken(userData);
        // return it 
        return Ok(jwtToken);
    }

}
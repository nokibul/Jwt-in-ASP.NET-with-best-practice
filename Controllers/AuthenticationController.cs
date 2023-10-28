using Microsoft.AspNetCore.Mvc;
using Agency.Models.MyContext;
using Agency.Models.DTOs;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    public readonly MyContext _context;
    public AuthenticationController(MyContext context)
    {
        _context = context;
    }

    // register
    [HttpPost]
    [HttpPost("register")]
    public async Task<ActionResult<UserDataDTO>> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
    {
        // validate the request
        if (!ModelState.IsValid)
        {
            // Model validation failed.
            return BadRequest(ModelState);
        }
        // register the user using service
        // return the registered user detail data
        string sampleResponse = "dddol";
        return Ok(sampleResponse);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        string sampleResponse = "dddol";
        return Ok(sampleResponse);
    }

}
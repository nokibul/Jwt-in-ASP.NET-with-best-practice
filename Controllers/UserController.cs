using Microsoft.AspNetCore.Mvc;
using Agency.Models.MyContext;

[ApiController]
[Route("api/signup")]
public class SignUpController : ControllerBase
{
    public readonly MyContext _context;
    public SignUpController(MyContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
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
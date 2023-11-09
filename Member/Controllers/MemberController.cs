using Microsoft.AspNetCore.Mvc;
using Agency.Data.MyContext;

[ApiController]
[Route("api/agencies/{agencyId}/members")]
public class MemberController : ControllerBase
{
    public readonly Context _context;
    public MemberController(Context context)
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
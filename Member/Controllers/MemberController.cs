using Microsoft.AspNetCore.Mvc;
using Agency.Data.MyContext;
using Agency.Member.Interfaces;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/members")]
public class MemberController : ControllerBase
{
    public readonly IUserRepository _userRepository;
    public MemberController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var allMembers = await _userRepository.GetAllAsync();
        return Ok(allMembers);
    }

}
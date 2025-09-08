using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simulation_of_Currency_Sync.Models;
using Simulation_of_Currency_Sync.Repository;

namespace Simulation_of_Currency_Sync.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<User> GetAll()
    {
        var profiles = _repository.GetProfiles();

        if (profiles == null)
            return NotFound("No profile found");

        return Ok(profiles);
    }

    [HttpPost]
    public ActionResult<User> Post([FromBody] User user)
    {
        try
        {
            var createdProfile = _repository.CreateProfile(user);
            return Ok(createdProfile);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("by-email/{email}")]
    public ActionResult<User> Put(string email, [FromBody] User user)
    { 
        var existing = _repository.GetProfile(email);
        if (existing == null)
            return NotFound();

        _repository.UpdateProfile(user);

        return Ok(user);
    }
}

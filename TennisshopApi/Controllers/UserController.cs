using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class UserController : Controller
{

    private readonly IUserRepository _repository;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetUser()
    {
        var user = _repository.GetUser();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(user);
    }

}
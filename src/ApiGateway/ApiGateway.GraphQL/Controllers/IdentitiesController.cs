using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.GraphQL.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentitiesController : ControllerBase
{
    [HttpPost("register")]
    public void Register()
    {
    }
}
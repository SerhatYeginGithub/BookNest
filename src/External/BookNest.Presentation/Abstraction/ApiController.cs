using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Presentation.Abstraction;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class ApiController : ControllerBase
{
}

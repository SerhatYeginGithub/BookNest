using BookNest.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Presentation.Controllers;

public sealed class TestController : ApiController
{
    [HttpGet("[Action]")]
    public IActionResult Test()
    {
        return Ok("İşlem başarılı.");
    }

}

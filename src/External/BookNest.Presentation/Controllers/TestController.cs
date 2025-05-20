using BookNest.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Presentation.Controllers;

public class TestController : ApiController
{
    
    public TestController(IMediator mediator) : base(mediator)
    {
    }



}

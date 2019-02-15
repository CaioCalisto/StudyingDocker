using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IMediator mediator;


    }
}

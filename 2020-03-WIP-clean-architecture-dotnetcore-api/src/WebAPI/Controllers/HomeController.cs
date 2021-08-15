using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly IConfiguration _configuration;

        public HomeController(IMediator mediator, IConfiguration configuration) : base(mediator)
        {
            _configuration = configuration;
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            var swaggerUrl = _configuration.GetValue<string>("Swagger:Index");
            return Redirect(swaggerUrl);
        }
    }
}

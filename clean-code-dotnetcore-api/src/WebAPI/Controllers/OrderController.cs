using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new OrdersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] OrderWithProductsQuery query)
        {
            var result = await Mediator.Send(query ?? new OrderWithProductsQuery());
            return Ok(result);
        }
    }
}

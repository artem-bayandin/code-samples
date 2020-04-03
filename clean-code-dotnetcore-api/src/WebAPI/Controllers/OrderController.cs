using Application.Queries.Orders;
using Application.Queries.OrderWithProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] OrderWithProductsQuery query)
        {
            var result = await Mediator.Send(query ?? new OrderWithProductsQuery());
            return Ok(result);
        }
    }
}

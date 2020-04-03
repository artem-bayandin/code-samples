using Application.Queries.Products;
using Domain.Commands.CreateProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new ProductsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand request)
        {
            var data = await Mediator.Send(request);
            return Result(data);
        }
    }
}

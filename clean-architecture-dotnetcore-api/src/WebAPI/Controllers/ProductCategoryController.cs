using Application.Queries.ProductCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Controllers.Base;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : BaseController
    {
        public ProductCategoryController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new ProductCategoriesQuery());
            return Ok(result);
        }
    }
}

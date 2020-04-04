using Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebAPI.Infrastructure;

namespace WebAPI.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IActionResult Result(CommandResult command)
        {
            if (command.HasError)
            {
                return ContentResultWithModelStateErrors(command);
            }
            return Ok();
        }

        protected IActionResult Result<T>(CommandResult<T> command) // where T : class
        {
            if (command.HasError)
            {
                return ContentResultWithModelStateErrors(command);
            }
            return Ok(command.Result);
        }

        protected IActionResult ContentResultWithModelStateErrors(CommandResult command)
        {
            // TODO: should be refactored to camelCase props

            var formattedResult = new HttpCommandResultWithFailedValidation(command);

            return StatusCode(formattedResult.GetHttpStatusCode()
                , JsonConvert.SerializeObject(formattedResult, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            );
        }
    }
}

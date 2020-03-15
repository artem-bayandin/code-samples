using Domain.CommandResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WebAPI.Infrastructure;

namespace WebAPI.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public IActionResult Result(CommandResult command)
        {
            if (command.HasError)
            {
                return ContentResultWithModelStateErrors(command);
            }
            return Ok();
        }

        public IActionResult Result<T>(CommandResult<T> command) where T : class
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

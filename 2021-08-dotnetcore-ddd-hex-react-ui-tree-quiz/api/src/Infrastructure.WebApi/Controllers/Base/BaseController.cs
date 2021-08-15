using Domain.Ports.In.Result;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Infrastructure.WebApi.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Result(DomainRequestResult result)
        {
            if (result.Status != DomainRequestResultStatuses.Success)
            {
                return ResultWithErrors(result);
            }
            return Ok();
        }

        protected IActionResult Result<T>(DomainRequestResult<T> result)
        {
            if (result.Status != DomainRequestResultStatuses.Success)
            {
                return ResultWithErrors(result);
            }
            return Ok(result.Data);
        }

        protected IActionResult ResultWithErrors(DomainRequestResult result)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

            foreach (var error in result.Errors)
            {
                if (!errors.ContainsKey(error.PropertyName))
                {
                    errors[error.PropertyName] = new List<string>();
                }

                errors[error.PropertyName].Add(error.ErrorDescription);
            }

            // TODO: extend logic
            var statusCode = (int)HttpStatusCode.BadRequest;

            return StatusCode(statusCode, JsonConvert.SerializeObject(new { Errors = errors }, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            );
        }
    }
}

using Domain.Commands;
using System.Collections.Generic;
using System.Net;

namespace WebAPI.Infrastructure
{
    public class HttpCommandResultWithFailedValidation
    {
        private int _commandStatusCode;

        public Dictionary<string, List<string>> Errors { get; private set; } = new Dictionary<string, List<string>>();

        private HttpCommandResultWithFailedValidation()
        {
        }

        public HttpCommandResultWithFailedValidation(CommandResult commandResult)
        {
            foreach (var validationFailure in commandResult.Validation.Errors)
            {
                if (!Errors.ContainsKey(validationFailure.PropertyName))
                {
                    Errors[validationFailure.PropertyName] = new List<string>();
                }

                Errors[validationFailure.PropertyName].Add(validationFailure.ErrorMessage);
            }

            _commandStatusCode = commandResult.StatusCode;
        }

        public int GetHttpStatusCode()
        {
            switch (_commandStatusCode)
            {
                case (int)CommandResultStatuses.BadRequest:
                    return (int)HttpStatusCode.BadRequest;

                case (int)CommandResultStatuses.ServerError:
                    return (int)HttpStatusCode.InternalServerError;

                default:
                    return (int)HttpStatusCode.BadRequest;
            }
        }
    }
}

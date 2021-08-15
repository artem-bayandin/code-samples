using Domain.Ports.In.Result;
using FluentValidation;
using MediatR;

namespace Domain.PortsImplementation.BaseComponents
{
    public abstract class BaseHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
        where TResult : DomainRequestResult
    {
        public virtual async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            return await DoTheJob(request, cancellationToken);
        }

        protected abstract Task<TResult> DoTheJob(TRequest request, CancellationToken cancellationToken);
    }

    public abstract class BaseHandlerWithValidation<TRequest, TResult> : BaseHandler<TRequest, TResult>
        where TRequest : IRequest<TResult>
        where TResult : DomainRequestResult
    {
        private readonly IValidator<TRequest> _validator;

        public BaseHandlerWithValidation(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public override async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult
                    .Errors
                    .Select(x => new DomainRequestResultError(x.PropertyName, x.ErrorCode, x.ErrorMessage))
                    .ToList();
                var result = new DomainRequestResult();
                result.SetErrors(errors);
                result.SetStatus(DomainRequestResultStatuses.ValidationFailed);
                return result as TResult;
            }

            return await base.Handle(request, cancellationToken);
        }
    }
}

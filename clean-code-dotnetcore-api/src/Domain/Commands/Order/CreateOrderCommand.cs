using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Order
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        // some fields

        public enum CreateOrderCommandErrors
        {
            //[Description("Id should not be empty")]
            //EmptyOrderId
        }

        public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
        {
            // private readonly IShopContext _context;

            public CreateOrderCommandValidator(
                //ShopContext context
                )
            {
                //RuleFor(x => x.Id)
                //    .NotEmpty()
                //    .WithMessage(OrderWithProductsQueryErrors.EmptyOrderId)
                //    .MustAsync(OrderExists)
                //    .WithMessage((query, id) => ValidatorMessageExtensions.FormatMessage(OrderWithProductsQueryErrors.OrderDoesNotExist, id));
            }
        }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
        {
            //private readonly IShopContext _context;
            //private readonly IMapper _mapper;

            public CreateOrderCommandHandler(
                //ShopContext context
                )
            {
            }

            public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(Guid.NewGuid());
            }
        }
    }
}

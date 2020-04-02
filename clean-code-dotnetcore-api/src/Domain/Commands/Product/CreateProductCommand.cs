using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Product
{
    public class CreateProductCommand : IRequest<Guid>
    {
        // some fields

        public enum CreateProductCommandErrors
        {
            //[Description("Id should not be empty")]
            //EmptyOrderId
        }

        public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
        {
            // private readonly IShopContext _context;

            public CreateProductCommandValidator(
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

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
        {
            //private readonly IShopContext _context;
            //private readonly IMapper _mapper;

            public CreateProductCommandHandler(
                //ShopContext context
                )
            {
            }

            public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                return await Task.FromResult(Guid.NewGuid());
            }
        }
    }
}

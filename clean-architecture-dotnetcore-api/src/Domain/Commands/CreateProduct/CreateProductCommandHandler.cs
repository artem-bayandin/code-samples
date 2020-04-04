using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;
using AutoMapper;

namespace Domain.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommandResult<CreateCommandResult<Guid>>>
    {
        private readonly IShopContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommandResult<CreateCommandResult<Guid>>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var saved = await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return CommandResult<CreateCommandResult<Guid>>.Ok(new CreateCommandResult<Guid>(saved.Entity.Id));
        }
    }
}

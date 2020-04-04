using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CommandResult<CreateCommandResult<Guid>>>
    {
        private readonly IShopContext _context;

        public CreateOrderCommandHandler(IShopContext context)
        {
            _context = context;
        }

        public async Task<CommandResult<CreateCommandResult<Guid>>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = Order.Create();
            var plis = request.Products.Select(p => ProductLineItem.Create(order.Id, p.Id, p.Quantity)).ToList();

            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.ProductLineItems.AddRangeAsync(plis, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(CommandResult<CreateCommandResult<Guid>>.Ok(new CreateCommandResult<Guid>(order.Id)));
        }
    }
}

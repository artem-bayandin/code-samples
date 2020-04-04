using MediatR;
using System;
using System.Collections.Generic;
using Domain.Common.Models;

namespace Domain.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CommandResult<CreateCommandResult<Guid>>>
    {
        public List<ProductLineItemModel> Products { get; set; }
    }
}

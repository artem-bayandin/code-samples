using MediatR;
using System;

namespace Domain.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CommandResult<CreateCommandResult<Guid>>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}

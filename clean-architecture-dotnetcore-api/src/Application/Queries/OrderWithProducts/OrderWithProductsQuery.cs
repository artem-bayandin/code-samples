﻿using Application.Common.Models;
using MediatR;
using System;

namespace Application.Queries.OrderWithProducts
{
    public class OrderWithProductsQuery : IRequest<OrderWithProductsModel>
    {
        public Guid Id { get; set; }
    }
}

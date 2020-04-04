using Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; protected set; }

        public DateTime DateCreated { get; protected set; }
        public OrderStatus OrderStatus { get; protected set; }

        public List<ProductLineItem> ProductLineItems { get; protected set; }

        protected Order()
        {
            ProductLineItems = new List<ProductLineItem>();
        }

        public static Order Create() => Create(Guid.NewGuid());

        public static Order Create(Guid id)
        {
            return new Order
            {
                Id = id,
                DateCreated = DateTime.UtcNow,
                OrderStatus = OrderStatus.New
            };
        }
    }
}

using Domain.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public List<ProductLineItem> ProductLineItems { get; set; }

        public Order()
        {
            ProductLineItems = new List<ProductLineItem>();
        }
    }
}

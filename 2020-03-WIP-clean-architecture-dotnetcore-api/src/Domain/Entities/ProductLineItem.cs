using System;

namespace Domain.Entities
{
    public class ProductLineItem
    {
        public Guid OrderId { get; protected set; }
        public Guid ProductId { get; protected set; }
        
        public int Quantity { get; protected set; }

        public virtual Order Order { get; protected set; }
        public virtual Product Product { get; protected set; }

        public static ProductLineItem Create(Guid orderId, Guid productId, int quantity)
        {
            return new ProductLineItem
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantity
            };
        }
    }
}

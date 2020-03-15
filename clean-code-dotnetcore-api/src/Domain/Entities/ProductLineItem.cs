using System;

namespace Domain.Entities
{
    public class ProductLineItem
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

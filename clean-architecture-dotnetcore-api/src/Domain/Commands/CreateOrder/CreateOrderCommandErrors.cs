using System.ComponentModel;

namespace Domain.Commands.CreateOrder
{
    public enum CreateOrderCommandErrors
    {
        [Description("Order should contain at least one product to be created")]
        OrderShouldContainAtLeastOneProduct
    }
}

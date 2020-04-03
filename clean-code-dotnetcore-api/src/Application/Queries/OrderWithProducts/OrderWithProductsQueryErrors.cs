using System.ComponentModel;

namespace Application.Queries.OrderWithProducts
{
    public enum OrderWithProductsQueryErrors
    {
        [Description("Id should not be empty")]
        EmptyOrderId,

        [Description("Order with id '{0}' does not exist")]
        OrderDoesNotExist
    }
}

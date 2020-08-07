using System.Collections.Generic;
using IProduct = Product.IProduct;

namespace Promotion
{
    public class OrderDetails : IOrderDetails
    {
        public IList<IProduct> Products;

        public OrderDetails()
        {
            Products = new List<IProduct>();
        }

        public void AddBasket(IProduct product)
        {
            Products.Add(product);
        }
    }
}
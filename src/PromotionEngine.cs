using System.Collections.Generic;
using System.Linq;

namespace Promotion
{
    public class PromotionEngine
    {
        private readonly IOrderDetails myOrderDetails;

        public PromotionEngine(IOrderDetails orderDetails)
        {
            myOrderDetails = orderDetails;
        }

        public int ApplyPromotion()
        {
            var promotionFactory = new PromotionFactory();
            var promotionsApplicable = promotionFactory.GetPromotions();
            var totalValueOfProducts = 0;

            foreach(var promotion in promotionsApplicable)
            {
                var products = GetProductsLinkedWithThePromotion(promotion);
                totalValueOfProducts += promotion.Apply(products);
            }

            return totalValueOfProducts;
        }

        private IList<Product.IProduct> GetProductsLinkedWithThePromotion(IPromotion promotion)
        {
            return myOrderDetails.Products.Where(product => promotion.PromotionLinkedWithPlan.Contains(product.ProductName)).ToList();
        }
    }
}

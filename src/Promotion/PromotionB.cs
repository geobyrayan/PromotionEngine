using System;
using System.Collections.Generic;

namespace Promotion
{
    public class PromotionB : IPromotion
    {
        private int myMinimumProductInCartToAvailPromotion = 2;

        private int myPromotionalPrice = 45;

        public IList<string> PromotionLinkedWithPlan { get => new List<string>() {"ProductB"}; }
        
        public int Apply(IList<Product.IProduct> products)
        {
            var product = products[0];
            return GetTotalValueOfProduct(product);
        }

        private int GetTotalValueOfProduct(Product.IProduct product)
        {
            var promotionalValue = (int)Math.Floor((double)(product.ProductCount / myMinimumProductInCartToAvailPromotion));

            var totalValueOfProduct = (promotionalValue * myPromotionalPrice) +
                                ((product.ProductCount % myMinimumProductInCartToAvailPromotion) * product.ProductValue);
            return totalValueOfProduct;
        }
    }
}
using System;
using System.Collections.Generic;
using Product;

namespace Promotion
{
    public class PromotionA : IPromotion
    {
        private int myPromotionalPrice = 130;
        
        private int myMinimumProductInCartToAvailPromotion = 3;

        public IList<string> PromotionLinkedWithPlan { get => new List<string>() {"ProductA"}; }

        public int Apply(IList<IProduct> products)
        {
            var product = products[0];

            return GetTotalValueOfProduct(product);
        }

        private int GetTotalValueOfProduct(IProduct product)
        {
            var promotionalValue = (int)Math.Floor((double)(product.ProductCount / myMinimumProductInCartToAvailPromotion));

            var totalValueOfProductA = (promotionalValue * myPromotionalPrice) +
                                ((product.ProductCount % myMinimumProductInCartToAvailPromotion) * product.ProductValue);
                                
            return totalValueOfProductA;
        }
    }
}
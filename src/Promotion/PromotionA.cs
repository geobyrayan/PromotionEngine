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
            throw new NotImplementedException();
        }
    }
}
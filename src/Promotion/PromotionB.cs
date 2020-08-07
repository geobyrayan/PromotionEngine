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
            throw new NotImplementedException();
        }
    }
}
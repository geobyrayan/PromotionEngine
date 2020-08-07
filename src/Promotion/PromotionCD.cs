using System;
using System.Collections.Generic;
using System.Linq;

namespace Promotion
{
    public class PromotionCD : IPromotion
    {
        private int myPromotionalPrice = 30;

        public IList<string> PromotionLinkedWithPlan { get => new List<string>() { "ProductC", "ProductD" }; }

        public int Apply(IList<Product.IProduct> products)
        {
            throw new NotImplementedException();
        }
    }
}
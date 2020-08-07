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
            var productC = products.Where(product => product.ProductName.Equals("ProductC")).SingleOrDefault();
            var productD = products.Where(product => product.ProductName.Equals("ProductD")).SingleOrDefault();

            var totalUnitsC = productC.ProductCount;
            var totalUnitsD = productD.ProductCount;

            var leastValuedProduct = Math.Min(totalUnitsC, totalUnitsD);
            var maxValueProduct = Math.Max(totalUnitsC, totalUnitsD);

            var totalValueOfProducts = 0;
            if (totalUnitsC > totalUnitsD)
            {
                totalValueOfProducts += ((leastValuedProduct * myPromotionalPrice) + ((maxValueProduct - leastValuedProduct) * productC.ProductValue));
            }
            else if (totalUnitsD > totalUnitsC)
            {
                totalValueOfProducts += ((leastValuedProduct * myPromotionalPrice) + ((maxValueProduct - leastValuedProduct) * productD.ProductValue));
            }
            else
            {
                totalValueOfProducts += (leastValuedProduct * myPromotionalPrice);
            }

            return totalValueOfProducts;
        }
    }
}
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

            int totalValueOfProducts = GetTotalValue(productC, productD, totalUnitsC, totalUnitsD, leastValuedProduct, maxValueProduct);

            return totalValueOfProducts;
        }

        private int GetTotalValue(Product.IProduct productC, Product.IProduct productD, int totalUnitsC, int totalUnitsD, int leastValuedProduct, int maxValueProduct)
        {
            var totalValueOfProducts = 0;
            int promotionalValue = (leastValuedProduct * myPromotionalPrice);

            if (totalUnitsC > totalUnitsD)
            {
                totalValueOfProducts = (promotionalValue + GetIndividualValueForProduct(productC, leastValuedProduct, maxValueProduct));
            }
            else if (totalUnitsD > totalUnitsC)
            {
                totalValueOfProducts = (promotionalValue + GetIndividualValueForProduct(productD, leastValuedProduct, maxValueProduct));
            }
            else
            {
                totalValueOfProducts = promotionalValue;
            }

            return totalValueOfProducts;
        }

        private static int GetIndividualValueForProduct(Product.IProduct product, int leastValuedProduct, int maxValueProduct)
        {
            return ((maxValueProduct - leastValuedProduct) * product.ProductValue);
        }
    }
}
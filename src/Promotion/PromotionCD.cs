using System;
using System.Collections.Generic;
using System.Linq;
using IProduct = Product.IProduct;

namespace Promotion
{
    public class PromotionCD : IPromotion
    {
        private int myPromotionalPrice = 30;

        public IList<string> PromotionLinkedWithPlan { get => new List<string>() { "ProductC", "ProductD" }; }

        public int Apply(IList<IProduct> products)
        {
            var productC = products.Where(product => product.ProductName.Equals("ProductC")).SingleOrDefault();
            var productD = products.Where(product => product.ProductName.Equals("ProductD")).SingleOrDefault();

            return GetTotalValueOfProducts(productC, productD);
        }

        private int GetTotalValueOfProducts(IProduct productC, IProduct productD)
        {
            var totalUnitsC = productC.ProductCount;
            var totalUnitsD = productD.ProductCount;

            var noOfProductsPairForPromotionApply = Math.Min(totalUnitsC, totalUnitsD);
            var maxValueProduct = Math.Max(totalUnitsC, totalUnitsD);

            var totalValueOfProducts = 0;
            int promotionalValue = GetValueForProductsWithPromotionApplied(noOfProductsPairForPromotionApply);

            if (totalUnitsC > totalUnitsD)
            {
                totalValueOfProducts = (promotionalValue + 
                                        GetIndividualValueForProduct(productC, noOfProductsPairForPromotionApply, maxValueProduct));
            }
            else if (totalUnitsD > totalUnitsC)
            {
                totalValueOfProducts = (promotionalValue + 
                                        GetIndividualValueForProduct(productD, noOfProductsPairForPromotionApply, maxValueProduct));
            }
            else
            {
                totalValueOfProducts = promotionalValue;
            }

            return totalValueOfProducts;
        }

        private int GetValueForProductsWithPromotionApplied(int noOfProductsPairForPromotionApply)
        {
            return (noOfProductsPairForPromotionApply * myPromotionalPrice);
        }

        private static int GetIndividualValueForProduct(IProduct product, int noOfProductsPairForPromotionApply, int maxValueProduct)
        {
            int noOfProductsWithoutPromotion = (maxValueProduct - noOfProductsPairForPromotionApply);
            return noOfProductsWithoutPromotion * product.ProductValue;
        }
    }
}
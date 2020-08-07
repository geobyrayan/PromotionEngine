using System;

namespace Promotion
{
    public class PromotionEngine
    {
        private readonly int totalUnitA;
        private readonly int totalUnitB;
        private readonly int totalUnitC;
        private readonly int totalUnitD;

        private readonly int myProductAValue = 50;

        private readonly int myProductBValue = 30;

        private readonly int myProductCValue = 20;

        private readonly int myProductDValue = 15;

        public PromotionEngine(int totalUnitA, int totalUnitB, int totalUnitC, int totalUnitD)
        {
            this.totalUnitA = totalUnitA;
            this.totalUnitB = totalUnitB;
            this.totalUnitC = totalUnitC;
            this.totalUnitD = totalUnitD;
        }

        public double GetDiscountedAmount()
        {
            var totalValueOfProducts = 0;

            //Calculation of product A
            if (this.totalUnitA > 0)
            {
                var promotionalValue = (int)Math.Floor((double)(this.totalUnitA / 3));
                totalValueOfProducts += (promotionalValue * 130) + ((this.totalUnitA % 3) * myProductAValue);
            }

            //Calculation of Product B
            if (this.totalUnitB > 0)
            {
                var promotionalValue = (int)Math.Floor((double)(this.totalUnitB / 2));
                totalValueOfProducts += (promotionalValue * 45) + ((this.totalUnitB % 2) * myProductBValue);
            }

            //Calculation of Product C and D
            var leastValuedProduct = Math.Min(this.totalUnitC, this.totalUnitD);
            var maxValueProduct = Math.Max(this.totalUnitC, this.totalUnitD);

            if(this.totalUnitC > this.totalUnitD) {
                totalValueOfProducts += ((leastValuedProduct * 30) + ((maxValueProduct-leastValuedProduct) * myProductCValue));
            }
            else if(this.totalUnitD > this.totalUnitC){
                totalValueOfProducts += ((leastValuedProduct * 30) + ((maxValueProduct-leastValuedProduct) * myProductDValue));
            }
            else {
                totalValueOfProducts += (leastValuedProduct * 30);
            }

            return totalValueOfProducts;
        }
    }
}
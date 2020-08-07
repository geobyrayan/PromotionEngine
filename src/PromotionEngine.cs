using System;

namespace Promotion
{
    public class PromotionEngine
    {
        private readonly int totalUnitA;
        private readonly int totalUnitB;
        private readonly int totalUnitC;
        private readonly int totalUnitD;

        public PromotionEngine(int totalUnitA, int totalUnitB, int totalUnitC, int totalUnitD)
        {
            this.totalUnitA = totalUnitA;
            this.totalUnitB = totalUnitB;
            this.totalUnitC = totalUnitC;
            this.totalUnitD = totalUnitD;
        }

        public double GetDiscountedAmount()
        {
            throw new NotImplementedException();
        }
    }
}
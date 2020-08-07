using System;

namespace Product
{
    public class ProductD : IProduct
    {
        private readonly int totalUnits;

        public string ProductName { get => "ProductD"; }

        public int ProductValue { get => 15; }

        public int ProductCount { get => this.totalUnits; }

        public ProductD(int totalUnits)
        {
            this.totalUnits = totalUnits;
        }
    }
}
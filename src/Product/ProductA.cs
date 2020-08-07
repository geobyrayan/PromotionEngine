using System;

namespace Product
{
    public class ProductA : IProduct
    {
        private readonly int totalUnits;

        public string ProductName { get => "ProductA"; }

        public int ProductValue { get => 50; }

        public int ProductCount { get => this.totalUnits; }

        public ProductA(int totalUnits)
        {
            this.totalUnits = totalUnits;
        }
    }
}
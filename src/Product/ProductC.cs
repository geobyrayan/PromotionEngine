using System;

namespace Product
{
    public class ProductC : IProduct
    {
        private readonly int totalUnits;

        public string ProductName { get => "ProductC"; }

        public int ProductValue { get => 20; }

        public int ProductCount { get => this.totalUnits; }

        public ProductC(int totalUnits)
        {
            this.totalUnits = totalUnits;
        }
    }
}
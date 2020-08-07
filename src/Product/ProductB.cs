using System;

namespace Product
{
    public class ProductB : IProduct
    {
        private readonly int totalUnits;
        
        public string ProductName { get => "ProductB"; }

        public int ProductValue { get => 30; }

        public int ProductCount { get => this.totalUnits; }

        public ProductB(int totalUnits)
        {
            this.totalUnits = totalUnits;
        }
    }
}
using System;

namespace Product
{
    public interface IProduct
    {
        int ProductCount { get; }

        string ProductName { get; }

        int ProductValue { get; }
    }
}
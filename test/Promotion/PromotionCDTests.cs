using Xunit;
using Moq;
using System.Collections.Generic;
using Product;

public class PromotionCDTests
{
    [Theory]
    [InlineData(0,0, 0)]
    [InlineData(1,1, 30)]
    [InlineData(1,0, 20)]
    [InlineData(0,1, 15)]
    public void Apply_WithLessThanMinimumProductForPromotionToBeAvailed_NoPromotionApplied(int productCCount, int productDCount, int expectedValue)
    {
        var productC = SetupProduct("ProductC", 20, productCCount);
        var productD = SetupProduct("ProductD", 15, productDCount);

        IList<Product.IProduct> products = new List<Product.IProduct>() { productC, productD };

        var promotion = new Promotion.PromotionCD();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(expectedValue, totalValueOfProduct);
    }

    [Theory]
    [InlineData(7,5, 190)]
    [InlineData(5,7, 180)]
    [InlineData(5,5, 150)]
    public void Apply_WithMoreThanMinimumProductForPromotionToBeAvailed_PromotionAppliedForRelevantProducts(int productCCount, int productDCount, int expectedValue)
    {
        var productC = SetupProduct("ProductC", 20, productCCount);
        var productD = SetupProduct("ProductD", 15, productDCount);

        IList<Product.IProduct> products = new List<Product.IProduct>() { productC, productD };

        var promotion = new Promotion.PromotionCD();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(expectedValue, totalValueOfProduct);
    }

    private static IProduct SetupProduct(string productName, int productValue, int productCount)
    {
        var product = new Mock<Product.IProduct>();
        product.Setup(p => p.ProductName).Returns(productName);
        product.Setup(p => p.ProductValue).Returns(productValue);
        product.Setup(p => p.ProductCount).Returns(productCount);
        
        return product.Object;
    }
}
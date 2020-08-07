using Xunit;
using Moq;
using System.Collections.Generic;
using Product;

public class PromotionCDTests
{
    [Fact]
    public void Apply_WithLessThanMinimumProductForPromotionToBeAvailed_NoPromotionApplied()
    {
        var productC = SetupProduct("ProductC", 20, 0);
        var productD = SetupProduct("ProductD", 15, 0);

        IList<Product.IProduct> products = new List<Product.IProduct>() { productC, productD };

        var promotion = new Promotion.PromotionCD();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(totalValueOfProduct, 0);
    }

    [Fact]
    public void Apply_WithMinimumProductForPromotionToBeAvailed_PromotionApplied()
    {
        var productC = SetupProduct("ProductC", 20, 1);
        var productD = SetupProduct("ProductD", 15, 1);

        IList<Product.IProduct> products = new List<Product.IProduct>() { productC, productD };

        var promotion = new Promotion.PromotionCD();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(totalValueOfProduct, 30);
    }

    [Theory]
    [InlineData(7,5, 190)]
    [InlineData(5,7, 190)]
    public void Apply_WithMoreThanMinimumProductForPromotionToBeAvailed_PromotionAppliedForRelevantProducts(int productCCount, int productDCount, int expectedValue)
    {
        var productC = SetupProduct("ProductC", 20, productCCount);
        var productD = SetupProduct("ProductD", 15, productDCount);

        IList<Product.IProduct> products = new List<Product.IProduct>() { productC, productD };

        var promotion = new Promotion.PromotionCD();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(totalValueOfProduct, expectedValue);
    }

    private static IProduct SetupProduct(string productName, int productValue, int productCount)
    {
        var product = new Mock<Product.IProduct>();
        product.Setup(p => p.ProductName).Returns(productName);
        product.Setup(p => p.ProductValue).Returns(productValue);
        product.Setup(p => p.ProductCount).Returns(productCount);
        
        return product.Object;

        //
        //return products;
    }
}
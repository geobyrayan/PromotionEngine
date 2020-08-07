using Xunit;
using Moq;
using System.Collections.Generic;
using Product;

public class PromotionATests
{
    [Fact]
    public void Apply_WithLessThanMinimumProductForPromotionToBeAvailed_NoPromotionApplied()
    {
        IList<IProduct> products = SetupProduct("ProductA", 50, 2);

        var promotion = new Promotion.PromotionA();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(100, totalValueOfProduct);
    }

    [Fact]
    public void Apply_WithMinimumProductForPromotionToBeAvailed_PromotionApplied()
    {
        IList<IProduct> products = SetupProduct("ProductA", 50, 3);

        var promotion = new Promotion.PromotionA();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(130, totalValueOfProduct);
    }

    [Fact]
    public void Apply_WithMoreThanMinimumProductForPromotionToBeAvailed_PromotionAppliedForRelevantProducts()
    {
        IList<IProduct> products = SetupProduct("ProductA", 50, 5);

        var promotion = new Promotion.PromotionA();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(230, totalValueOfProduct);
    }

    private static IList<IProduct> SetupProduct(string productName, int productValue, int productCount)
    {
        var product = new Mock<Product.IProduct>();
        product.Setup(p => p.ProductName).Returns(productName);
        product.Setup(p => p.ProductValue).Returns(productValue);
        product.Setup(p => p.ProductCount).Returns(productCount);

        IList<Product.IProduct> products = new List<Product.IProduct>() { product.Object };
        return products;
    }
}
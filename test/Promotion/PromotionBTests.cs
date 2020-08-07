using Xunit;
using Moq;
using System.Collections.Generic;
using Product;

public class PromotionBTests
{
    [Fact]
    public void Apply_WithLessThanMinimumProductForPromotionToBeAvailed_NoPromotionApplied()
    {
        IList<IProduct> products = SetupProduct("ProductB", 30, 1);

        var promotion = new Promotion.PromotionB();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(30, totalValueOfProduct);
    }

    [Fact]
    public void Apply_WithMinimumProductForPromotionToBeAvailed_PromotionApplied()
    {
        IList<IProduct> products = SetupProduct("ProductB", 30, 2);

        var promotion = new Promotion.PromotionB();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(45, totalValueOfProduct);
    }

    [Fact]
    public void Apply_WithMoreThanMinimumProductForPromotionToBeAvailed_PromotionAppliedForRelevantProducts()
    {
        IList<IProduct> products = SetupProduct("ProductB", 30, 3);

        var promotion = new Promotion.PromotionB();
        var totalValueOfProduct = promotion.Apply(products);

        Assert.Equal(75, totalValueOfProduct);
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
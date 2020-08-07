using Xunit;

public class PromotionEngineTests
{
    [Theory]
    [InlineData(1,1,1,0,100)]
    [InlineData(1,1,0,1,95)]
    [InlineData(1,0,1,1,80)]
    [InlineData(0,1,1,1,60)]
    public void GetDiscountedAmount_WithOneProductOnEachSKU_NoPromotionApplied(int productA, int productB, int productC, int  productD, int expectedAmount)
    {
        var promotionEngine = new Promotion.PromotionEngine(productA, productB, productC, productD);
        var discountedAmount = promotionEngine.GetDiscountedAmount();

        Assert.Equal(discountedAmount, expectedAmount);
    }

    [Theory]
    [InlineData(5,5,1,0,370)]
    [InlineData(3,5,1,1,280)]
    [InlineData(3,2,1,1,205)]
    [InlineData(2,6,5,5,385)]
    [InlineData(2,6,7,5,425)]
    [InlineData(2,6,5,7,415)]
    public void GetDiscountedAmount_WithCombinationOfProductsOnEachSKU_PromotionApplied(int productA, int productB, int productC, int  productD, int expectedAmount)
    {
        var promotionEngine = new Promotion.PromotionEngine(productA, productB, productC, productD);
        var discountedAmount = promotionEngine.GetDiscountedAmount();
        Assert.Equal(discountedAmount, expectedAmount);
    }
}
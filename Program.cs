using System;

namespace Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderDetails orderDetails = new OrderDetails();

            Console.WriteLine("Enter Number of Product A: ");
            var totalUnitA = Convert.ToInt32(Console.ReadLine());
            Product.IProduct productA = new Product.ProductA(totalUnitA);
            orderDetails.AddBasket(productA);

            Console.WriteLine("Enter Number of Product B: ");
            var totalUnitB = Convert.ToInt32(Console.ReadLine());
            Product.IProduct productB = new Product.ProductB(totalUnitB);
            orderDetails.AddBasket(productB);

            Console.WriteLine("Enter Number of Product C: ");
            var totalUnitC = Convert.ToInt32(Console.ReadLine());
            Product.IProduct productC = new Product.ProductC(totalUnitC);
            orderDetails.AddBasket(productC);

            Console.WriteLine("Enter Number of Product D: ");
            var totalUnitD = Convert.ToInt32(Console.ReadLine());
            Product.IProduct productD = new Product.ProductD(totalUnitD);
            orderDetails.AddBasket(productD);

            //PromotionEngine promotionEngine = new PromotionEngine(orderDetails);
            //var discountedAmount = promotionEngine.ApplyPromotion();

            //Console.WriteLine("Total Value after applying promotion is : {0}", discountedAmount);
        }
    }
}
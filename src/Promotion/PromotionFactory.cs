using System.Collections.Generic;

namespace Promotion
{
    public class PromotionFactory
    {
        public IList<IPromotion> GetPromotions()
        {
            return new List<IPromotion>() {
                new PromotionA(),
                new PromotionB(),
                new PromotionCD()
            };
        }
    }
}
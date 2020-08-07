using System;
using System.Collections.Generic;
using Product;

namespace Promotion
{
    public interface IPromotion
    {
        int Apply(IList<IProduct> product);

        IList<string> PromotionLinkedWithPlan { get; }
    }
}
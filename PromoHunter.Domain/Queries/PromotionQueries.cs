using System;
using System.Linq.Expressions;
using System.Linq;
using PromoHunter.Domain.Entities;
using System.Collections.Generic;

namespace PromoHunter.Domain.Queries
{
    public static class PromotionQueries
    {
        public static Expression<Func<Promotion, bool>> GetAllByStore(string storeName)
        {
            return x => x.StoreName == storeName;
        }
    }
}
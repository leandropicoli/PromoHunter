using System;
using System.Linq.Expressions;
using System.Linq;
using PromoHunter.Domain.Entities;
using System.Collections.Generic;

namespace PromoHunter.Domain.Queries
{
    public static class PromotionQueries
    {
        public static Expression<Func<IEnumerable<Promotion>, IEnumerable<Promotion>>> GetAll(int page, int limit)
        {
            return x => x.OrderBy(y => y.CreateDate)
                .Skip(page * limit)
                .Take(limit);
        }
    }
}
using System.Collections.Generic;
using PromoHunter.Domain.Entities;
using PromoHunter.Domain.Repositories;

namespace PromoHunter.Domain.Tests.Repositories
{
    public class FakePromotionRepository : IPromotionRepository
    {
        public IEnumerable<Promotion> GetPromotions(int page, int limit)
        {
            return new List<Promotion>();
        }

        public void SavePromotion(Promotion promotion)
        {

        }
    }
}
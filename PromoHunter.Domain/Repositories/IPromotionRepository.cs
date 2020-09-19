using System.Collections.Generic;
using PromoHunter.Domain.Entities;

namespace PromoHunter.Domain.Repositories
{
    public interface IPromotionRepository
    {
        void SavePromotion(Promotion promotion);
        IEnumerable<Promotion> GetPromotions(int page, int limit);
    }
}
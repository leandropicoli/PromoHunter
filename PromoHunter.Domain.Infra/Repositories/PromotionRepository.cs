using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PromoHunter.Domain.Entities;
using PromoHunter.Domain.Infra.Contexts;
using PromoHunter.Domain.Repositories;

namespace PromoHunter.Domain.Infra.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly DataContext _context;

        public PromotionRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Promotion> GetPromotions(int page, int limit)
        {
            //TODO: Change to queries
            return _context.Promotions
                .AsNoTracking()
                .Skip(page * limit)
                .Take(limit)
                .OrderBy(x => x.CreateDate);
        }

        public void SavePromotion(Promotion promotion)
        {
            _context.Promotions.Add(promotion);
            _context.SaveChanges();
        }
    }
}
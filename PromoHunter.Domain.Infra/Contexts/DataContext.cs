using Microsoft.EntityFrameworkCore;
using PromoHunter.Domain.Entities;

namespace PromoHunter.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Promotion> Promotions { get; set; }
    }
}
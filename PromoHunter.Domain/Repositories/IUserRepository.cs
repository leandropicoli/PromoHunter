using PromoHunter.Domain.Entities;

namespace PromoHunter.Domain.Repositories
{
    public interface IUserRepository
    {
        void SaveUser(User user);
    }
}
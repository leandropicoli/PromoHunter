using PromoHunter.Domain.Enums;

namespace PromoHunter.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
            Role = EUserType.User;
            Points = 0;
        }

        public EUserType Role { get; private set; }
        public int Points { get; private set; }

        public void UpdateUserRole(EUserType role)
        {
            Role = role;
        }

        public void UpdateUserPoints(int points)
        {
            Points = points;
        }

    }
}
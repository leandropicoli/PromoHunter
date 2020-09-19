using PromoHunter.Domain.Entities;

namespace PromoHunter.Domain.Repositories
{
    public interface ICommentRepository
    {
        void SaveComment(Comment comment);
    }
}
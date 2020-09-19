using System;

namespace PromoHunter.Domain.Entities
{
    public class Comment : Entity
    {
        public Comment(string user, Guid promotion, string text)
        {
            User = user;
            Promotion = promotion;
            Likes = 0;
            Text = text;
            CreateDate = DateTime.Now;
        }

        public string User { get; private set; }
        public Guid Promotion { get; private set; }
        public int Likes { get; private set; }
        public string Text { get; private set; }
        public DateTime CreateDate { get; private set; }

        public void UpdateLikes(int likes)
        {
            Likes = likes;
        }

        public override string ToString()
        {
            return Text;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromoHunter.Domain.Entities
{
    public class Promotion : Entity
    {
        private readonly IList<Comment> _comments;

        public Promotion(string name, string storeName, string promotionLink, string user)
        {
            Name = name;
            StoreName = storeName;
            PromotionLink = promotionLink;
            Likes = 0;
            _comments = new List<Comment>();
            Views = 0;
            CommentsCount = 0;
            User = user;
            CreateDate = DateTime.Now;
        }

        public string Name { get; private set; }
        public string StoreName { get; private set; }
        public string PromotionLink { get; private set; }
        public int Likes { get; private set; }
        public IReadOnlyCollection<Comment> Comments => _comments.ToArray();
        public int CommentsCount { get; set; }
        public int Views { get; private set; }
        public string User { get; private set; }
        public DateTime CreateDate { get; private set; }

        public void UpdateLikes(int likes)
        {
            Likes = likes;
        }

        public void UpdateViews(int views)
        {
            Views = views;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
            CommentsCount++;
        }

        public void UpdateComments(int count)
        {
            CommentsCount = count;
        }

    }
}
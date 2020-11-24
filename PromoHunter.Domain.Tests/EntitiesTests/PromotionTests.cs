using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoHunter.Domain.Entities;

namespace PromoHunter.Domain.Tests.EntitiesTests
{
    [TestClass]
    public class PromotionTests
    {
        private Promotion _promotion;

        [TestInitialize]
        public void Setup()
        {
            _promotion = new Promotion("Promotion", "Amazon", "https://www.amazon.com", "usertest123");
        }

        [TestMethod]
        public void GivenANewPromotion_ShouldLikesBeZero()
        {
            Assert.AreEqual(0, _promotion.Likes);
        }

        [TestMethod]
        public void GivenANewPromotion_ShouldCommentsCountBeZero()
        {
            Assert.AreEqual(0, _promotion.CommentsCount);
        }

        [TestMethod]
        public void GivenANewPromotion_ShouldViewsBeZero()
        {
            Assert.AreEqual(0, _promotion.Views);
        }

        [TestMethod]
        public void GivenANewComment_ShouldAddNewCommentAndUpdateViewCounts()
        {
            _promotion.AddComment(new Comment("anoterUser", new System.Guid(), "Nice one"));

            Assert.AreEqual(1, _promotion.CommentsCount);
            Assert.AreEqual("Nice one", _promotion.Comments.FirstOrDefault().Text);
        }

    }
}
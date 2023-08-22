using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoHunter.Domain.Entities;
using PromoHunter.Domain.Queries;

namespace PromoHunter.Domain.Tests.QueryTests
{
    [TestClass]
    public class PromotionQueriesTests
    {
        private List<Promotion> _promotions;

        public PromotionQueriesTests()
        {
            _promotions = new List<Promotion>();
            _promotions.Add(new Promotion("page 1", "amazon", "http://link.com/promo","http://link.com/image", "leandropicoli"));
            _promotions.Add(new Promotion("page 2", "amazon", "http://link.com/promo","http://link.com/image", "leandropicoli"));
            _promotions.Add(new Promotion("page 3", "amazon", "http://link.com/promo","http://link.com/image", "leandropicoli"));
        }

        [TestMethod]
        public void GivenAQuery_ShouldReturnPaginationCorrectly()
        {
            int page = 1;
            int take = 1;

            var result = _promotions.AsQueryable().Skip(page * take).Take(take).FirstOrDefault();

            Assert.AreEqual("page 2", result.Name);
        }

        [TestMethod]
        public void GivenAQuery_ShouldReturnAllPromotionsByStoreName()
        {
            var result = _promotions.AsQueryable().Where(PromotionQueries.GetAllByStore("amazon")).ToList();

            Assert.AreEqual(3, result.Count);
        }
    }
}
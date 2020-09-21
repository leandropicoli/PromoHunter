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
            _promotions.Add(new Promotion("page 1", "amazon", "http://link.com/promo", "leandropicoli"));
            _promotions.Add(new Promotion("page 2", "amazon", "http://link.com/promo", "leandropicoli"));
            _promotions.Add(new Promotion("page 3", "amazon", "http://link.com/promo", "leandropicoli"));
        }

        [TestMethod]
        public void GivenAQuery_ShouldReturnPaginationCorrectly()
        {
            // var result = _promotions.AsQueryable().Where(PromotionQueries.GetAll(1, 1));
            Assert.Fail();
        }
    }
}
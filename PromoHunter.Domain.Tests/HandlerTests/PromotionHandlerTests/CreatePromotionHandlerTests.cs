using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoHunter.Domain.Tests.Repositories;
using PromoHunter.Domain.Handlers;
using PromoHunter.Domain.Commands.PromotionCommands;
using PromoHunter.Domain.Commands;

namespace PromoHunter.Domain.Tests.HandlerTests.PromotionHandlerTests
{
    [TestClass]
    public class CreatePromotionHandlerTests
    {
        private readonly PromotionHandler _handler = new PromotionHandler(new FakePromotionRepository());

        [TestMethod]
        public void GivenAnInvalidCommand_ShouldNotCreatePromotion()
        {
            var command = new CreatePromotionCommand("", "", "", "", "");
            var result = (GenericCommandResult)_handler.Handle(command);

            Assert.AreEqual(false, result.Success);
        }

        [TestMethod]
        public void GivenAValidCommand_ShouldCreateCommand()
        {
            var url = "https://www.amazon.com/DualSense-Wireless-Controller-PlayStation-5/dp/B08FC6C75Y/ref=lp_16225016011_1_2?s=videogames-intl-ship&ie=UTF8&qid=1600544279&sr=1-2";
            var imageUrl = "http://image.com";
            var command = new CreatePromotionCommand("Playstation 5 Controller", "Amazon", url, imageUrl, "usertest123");
            var result = (GenericCommandResult)_handler.Handle(command);

            Assert.AreEqual(true, result.Success);
        }
    }
}
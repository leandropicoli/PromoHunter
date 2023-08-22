using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromoHunter.Domain.Commands.PromotionCommands;

namespace PromoHunter.Domain.Tests.CommandTests.PromotionCommandsTests
{
    [TestClass]
    public class CreatePromotionCommandTest
    {
        [TestMethod]
        public void GivenAnInvalidCommand_ShouldNotBeValid()
        {
            var command = new CreatePromotionCommand("", "", "", "", "");
            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }

        [TestMethod]
        public void GivenAValidCommand_ShouldBeValid()
        {
            var url = "https://www.amazon.com/DualSense-Wireless-Controller-PlayStation-5/dp/B08FC6C75Y/ref=lp_16225016011_1_2?s=videogames-intl-ship&ie=UTF8&qid=1600544279&sr=1-2";
            var imageUrl = "https://test.com";
            var command = new CreatePromotionCommand("Playstation 5 Controller", "Amazon", url, imageUrl, "usertest123");
            command.Validate();
            Assert.AreEqual(true, command.Valid);
        }

        [TestMethod]
        public void GivenAValidCommandWithInvalidUrl_ShouldNotBeValid()
        {
            var url = "NotAnUrl";
            var imageUrl = "https://test.com";
            var command = new CreatePromotionCommand("Playstation 5 Controller", "Amazon", url, imageUrl, "usertest123");
            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }
    }
}
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using TSundvall.DotnetCoreDevExp.LogWrapper;
using Xunit;

namespace LogWrapper.Test
{
    public class HomeControllerUnitTest
    {
        [Fact]
        public void PositiveTest()
        {
            // ------------------- SETUP -------------------
            var log = new Mock<ILoggerAdapter<HomeController>>();


            // // ------------------- EXECUTE -----------------
            var controller = new HomeController(log.Object);
            controller.Get();


            // // ------------------- VERIFY ------------------
            log.Verify(a => a.LogDebug(It.IsAny<string>(), It.IsAny<object[]>()), Times.Exactly(2));
        }
    }
}

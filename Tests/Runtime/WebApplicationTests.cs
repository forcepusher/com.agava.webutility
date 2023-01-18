using NUnit.Framework;

namespace Agava.WebUtility.Tests
{
    public class WebApplicationTests
    {
        [Test]
        public void InBackgroundShouldReturnFalse()
        {
            Assert.IsFalse(WebApplication.InBackground);
        }
    }
}

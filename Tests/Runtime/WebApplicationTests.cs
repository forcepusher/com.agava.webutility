using NUnit.Framework;

namespace Agava.WebUtility.Tests
{
    public class WebApplicationTests
    {
        [Test]
        public void ShouldReturnNotInBackground()
        {
            Assert.IsFalse(WebApplication.InBackground);
        }
    }
}

using NUnit.Framework;

namespace Agava.WebUtility.Tests
{
    public class DeviceTests
    {
        [Test]
        public void IsMobileShouldReturnFalse()
        {
            Assert.IsFalse(Device.IsMobile);
        }
    }
}

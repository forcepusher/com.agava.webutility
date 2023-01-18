using NUnit.Framework;

namespace Agava.WebUtility.Tests
{
    public class AdBlockTests
    {
        [Test]
        public void AdBlockEnabledShouldNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                UnityEngine.Debug.Log($"{nameof(AdBlock)}.{nameof(AdBlock.Enabled)} = {AdBlock.Enabled}");
            });
        }
    }
}

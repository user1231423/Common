using Common.Encoding.Hash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Common.Encoding
{
    [TestClass]
    public class TestHashService
    {
        [TestMethod]
        public void CreateMD5Hash()
        {
            var test = "Testing";

            var hashed = test.ToMD5();

            Assert.IsTrue(hashed.Length > 0);
        }

        [TestMethod]
        public void CreateSHA1Hash()
        {
            var test = "Testing";

            var hashed = test.ToSHA1();

            Assert.IsTrue(hashed.Length > 0);
        }

        [TestMethod]
        public void CreateSHA256Hash()
        {
            var test = "Testing";

            var hashed = test.ToSHA256();

            Assert.IsTrue(hashed.Length > 0);
        }
    }
}

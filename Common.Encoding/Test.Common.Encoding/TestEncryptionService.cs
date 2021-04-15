using Common.Encoding.Encryption;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Common.Encoding
{
    [TestClass]
    public class TestEncryptionService
    {
        [TestMethod]
        public void TripleDESEncryption()
        {
            var test = "Testing";

            var encrypted = test.Encrypt();

            var decrypted = test.Decrypt();

            Assert.IsTrue(decrypted == test);
        }
    }
}

namespace Common.Encoding.Encryption
{
    using Common.Encoding.Hash;
    using System;
    using System.Configuration;
    using System.Security.Cryptography;
    using System.Text;

    public static class EncryptionService
    {
        /// <summary>
        /// If App settings has no secret key, the default key is set to "Secret"
        /// </summary>
        private static readonly string Secret = string.IsNullOrEmpty(ConfigurationManager.AppSettings["EncryptionServiceSecret"]) ? "TestSecretKey" : ConfigurationManager.AppSettings["EncryptionServiceSecret"];

        /// <summary>
        /// Triple DES Encrypt string
        /// </summary>
        /// <param name="textToEncrypt"></param>
        /// <returns></returns>
        public static string Encrypt(this string textToEncrypt)
        {
            try
            {
                var encryptedTextArray = UTF8Encoding.UTF8.GetBytes(textToEncrypt);

                MD5CryptoServiceProvider MyMD5CryptoService = new MD5CryptoServiceProvider();

                var secretKeyArray = MyMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(Secret));

                MyMD5CryptoService.Clear();

                var tripleDESService = new TripleDESCryptoServiceProvider();

                var xx = tripleDESService.LegalKeySizes;

                tripleDESService.Key = secretKeyArray;

                tripleDESService.Mode = CipherMode.ECB;

                tripleDESService.Padding = PaddingMode.PKCS7;

                var cryptoTransformer = tripleDESService.CreateEncryptor();

                var encryptedTextBytes = cryptoTransformer.TransformFinalBlock(encryptedTextArray, 0, encryptedTextArray.Length);

                tripleDESService.Clear();

                return Convert.ToBase64String(encryptedTextBytes, 0, encryptedTextBytes.Length);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Triple DES Decrypt string
        /// </summary>
        /// <param name="textToDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt(this string textToDecrypt)
        {
            try
            {
                var decryptTextArray = Convert.FromBase64String(textToDecrypt);

                MD5CryptoServiceProvider MyMD5CryptoService = new MD5CryptoServiceProvider();

                var secretKeyArray = MyMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(Secret));

                MyMD5CryptoService.Clear();

                var tripleDESService = new TripleDESCryptoServiceProvider();

                tripleDESService.Key = secretKeyArray;

                tripleDESService.Mode = CipherMode.ECB;

                tripleDESService.Padding = PaddingMode.PKCS7;

                var cryptoTransformer = tripleDESService.CreateDecryptor();

                var decryptedTextBytes = cryptoTransformer.TransformFinalBlock(decryptTextArray, 0, decryptTextArray.Length);

                tripleDESService.Clear();

                return UTF8Encoding.UTF8.GetString(decryptedTextBytes);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}

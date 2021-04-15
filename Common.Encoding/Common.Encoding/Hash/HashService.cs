using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Encoding.Hash
{
    public static class HashService
    {
        /// <summary>
        /// Convert string to MD5 Hash
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static string ToMD5(this string stringToHash)
        {
            try
            {
                var hash = new MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
                return string.Concat(hash.Select(b => b.ToString("X2").Replace("-", "").ToString()));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Convert string to MD5 Hash
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static string MD5(string stringToHash)
        {
            try
            {
                var hash = new MD5CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
                return string.Concat(hash.Select(b => b.ToString("X2").Replace("-", "").ToString()));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Convert string to SHA1 Hash
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static string ToSHA1(this string stringToHash)
        {
            try
            {
                var hash = new SHA1Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
                return string.Concat(hash.Select(b => b.ToString("X2").Replace("-", "").ToString()));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Convert string to SHA1 Hash
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static string SHA1(string stringToHash)
        {
            try
            {
                var hash = new SHA1Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
                return string.Concat(hash.Select(b => b.ToString("X2").Replace("-", "").ToString()));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Convert string to SHA256
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static string ToSHA256(this string stringToHash)
        {
            try
            {
                var hash = new SHA256Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
                return string.Concat(hash.Select(b => b.ToString("X2").Replace("-", "").ToString()));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Convert string to SHA256
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static string SHA256(string stringToHash)
        {
            try
            {
                var hash = new SHA256Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
                return string.Concat(hash.Select(b => b.ToString("X2").Replace("-", "").ToString()));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

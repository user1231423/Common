using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Checks if a time has expceeded
        /// </summary>
        /// <param name="creationTime"></param>
        /// <param name="seconds"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static bool HasExceeded(this DateTime creationTime, int seconds, DateTime now)
        {
            return (now > creationTime.AddSeconds(seconds));
        }

        /// <summary>
        /// Get lifetime in secods
        /// </summary>
        /// <param name="creationTime"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static int GetLifetimeInSeconds(this DateTime creationTime, DateTime now)
        {
            return ((int)(now - creationTime).TotalSeconds);
        }

        /// <summary>
        /// Check if has expired
        /// </summary>
        /// <param name="expirationTime"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static bool HasExpired(this DateTime expirationTime, DateTime now)
        {
            if (now > expirationTime)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if expiration time is greater than current date
        /// </summary>
        /// <param name="expirationTime"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public static bool HasExpired(this DateTime? expirationTime, DateTime now)
        {
            if (expirationTime.HasValue &&
                expirationTime.Value.HasExpired(now))
            {
                return true;
            }

            return false;
        }

    }
}

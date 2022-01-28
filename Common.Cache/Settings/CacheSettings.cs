using Common.Cache.Enums;
using Common.Cache.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache.Settings
{
    public class CacheSettings : ICacheSettings
    {
        /// <summary>
        /// Absolute expiration in hours
        /// </summary>
        public int AbsoluteExpirationInHours { get; set; }

        /// <summary>
        /// Sliding expiration in minutes
        /// </summary>
        public int SlidingExpirationInMinutes{ get; set; }
    }
}

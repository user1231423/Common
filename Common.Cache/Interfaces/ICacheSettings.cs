using Common.Cache.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache.Interfaces
{
    public interface ICacheSettings
    {

        /// <summary>
        /// Absolute expiration in hours
        /// </summary>
        public int AbsoluteExpirationInHours { get; set; }

        /// <summary>
        /// Sliding expiration in minutes
        /// </summary>
        public int SlidingExpirationInMinutes { get; set; }
    }
}

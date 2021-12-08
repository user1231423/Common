using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Get authorization header form http context
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetAuthorizationHeader(this HttpContext httpContext)
        {
            return httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        }

    }
}

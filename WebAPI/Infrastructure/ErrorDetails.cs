using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

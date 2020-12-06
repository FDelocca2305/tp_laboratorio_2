using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosDeExtension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Retorno un long timestamp
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static long GetTimeStamp(this DateTime dato)
        { 
           return DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Framework.Log
{
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(Type type)
        {
            return new Log4NetLogger(type);
        }
    }
}

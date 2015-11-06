using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Framework.Log
{
    public class NullLoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(Type type)
        {
            return NullLogger.Instance;
        }
    }
}

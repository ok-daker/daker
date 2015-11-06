using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DChat.Framework.Log
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(Type type);
    }
}

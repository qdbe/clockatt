using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt.ConfigValue
{
    public class ConfigInitException : ArgumentException
    {
        public ConfigInitException(string msg) :
            base(msg)
        {
        }

        public ConfigInitException(string msg, Exception e) :
            base(msg,e)
        {
        }
    }
}

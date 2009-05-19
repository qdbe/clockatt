using System;
using System.Collections.Generic;
using System.Text;

namespace clockatt
{
    public abstract class configAbstract
    {
        private bool isWildCard(string words)
        {
            if (words == "*")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

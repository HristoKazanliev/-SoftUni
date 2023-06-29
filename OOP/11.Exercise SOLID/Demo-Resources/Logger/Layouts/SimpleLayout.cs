using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class SimpleLayout : Layout
    {
        private const string SimpleLayoutFormat = "{0} - {1} - {2}";

        public SimpleLayout() : base(SimpleLayoutFormat)
        {

        }
    }
}

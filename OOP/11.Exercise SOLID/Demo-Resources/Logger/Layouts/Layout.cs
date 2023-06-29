using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class Layout : ILayout
    {
        public Layout(string format)
        {
            this.Format = format;
        }

        public string Format { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.LogFiles
{
    public interface ILogFile
    {
        void Write(string message);
        int Size { get; }
    }
}

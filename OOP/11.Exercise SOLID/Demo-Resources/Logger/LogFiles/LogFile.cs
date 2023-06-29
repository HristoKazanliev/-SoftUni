using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger.LogFiles
{
    public class LogFile : ILogFile
    {
        private readonly StringBuilder stringBuilder;

        public LogFile() => stringBuilder = new StringBuilder();

        public int Size => this.stringBuilder
            .ToString()
            .Where(char.IsLetter)
            .Sum(x => x);

        public void Write(string message) => this.stringBuilder.Append(message);
    }
}

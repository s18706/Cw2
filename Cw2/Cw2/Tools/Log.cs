using System;
using System.IO;

namespace Cw2.Tools
{
    public class Log
    {
        private StreamWriter log;
        
        public Log()
        {
            log = new StreamWriter("log.txt",true);
        }

        public void WriteLine(string msg)
        {
            log.WriteLine(DateTime.Now + $" > {msg}");
            log.Flush();
        }
    }
}
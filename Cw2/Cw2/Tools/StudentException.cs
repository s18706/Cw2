using System;

namespace Cw2.Tools
{
    public class StudentException : Exception
    {
        public string Msg;
        public StudentException(string msg)
        {
            Msg = msg;
        }
    }
}
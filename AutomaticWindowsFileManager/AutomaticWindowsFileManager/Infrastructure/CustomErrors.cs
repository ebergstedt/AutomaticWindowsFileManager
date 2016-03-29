using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticWindowsFileManager.Infrastructure
{
    public class CustomErrors
    {
        public class FileFoundException : Exception
        {
            public FileFoundException(string message) : base(message)
            {
            }
        }
    }
}

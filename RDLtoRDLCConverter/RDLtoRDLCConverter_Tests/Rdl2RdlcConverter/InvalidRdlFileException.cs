using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Rdl2RdlcConverter
{
    public class InvalidRdlFileException : Exception
    {
        public InvalidRdlFileException() { }

        public InvalidRdlFileException(string message) : base(message) { }

        public InvalidRdlFileException(string message, Exception innerException) : base(message, innerException) { }

        protected InvalidRdlFileException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

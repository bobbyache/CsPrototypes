using System;
using System.Runtime.Serialization;

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

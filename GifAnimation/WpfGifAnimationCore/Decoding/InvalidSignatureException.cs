using System;
using System.Runtime.Serialization;

namespace GifAnimationCore.Decoding
{
    [Serializable]
    public class InvalidSignatureException : Exception
    {
        private object p;

        public InvalidSignatureException()
        {
        }

        public InvalidSignatureException(object p)
        {
            this.p = p;
        }

        public InvalidSignatureException(string message) : base(message)
        {
        }

        public InvalidSignatureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSignatureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
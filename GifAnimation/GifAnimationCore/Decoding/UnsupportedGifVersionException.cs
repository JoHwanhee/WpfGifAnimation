using System;
using System.Runtime.Serialization;

namespace GifAnimationCore.Decoding
{
    [Serializable]
    public class UnsupportedGifVersionException : Exception
    {
        private object p;

        public UnsupportedGifVersionException()
        {
        }

        public UnsupportedGifVersionException(object p)
        {
            this.p = p;
        }

        public UnsupportedGifVersionException(string message) : base(message)
        {
        }

        public UnsupportedGifVersionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsupportedGifVersionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
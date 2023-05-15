using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arrays.bytebank.Exception
{
  

    [System.Serializable]
    public class ByteBankExceptionsException : System.Exception
    {
        public ByteBankExceptionsException() { }
        public ByteBankExceptionsException(string message) : base("Aconteceu uma exceção ->" + message) { }
        public ByteBankExceptionsException(string message, System.Exception inner) : base(message, inner) { }
        protected ByteBankExceptionsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
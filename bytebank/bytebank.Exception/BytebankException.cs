using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank.bytebank.Exception
{

	[Serializable]
	public class BytebankException : System.Exception
	{
		public BytebankException() { }
		public BytebankException(string message) : base(message) { }
		public BytebankException(string message, System.Exception inner) : base("An error has ocurred which returned this exception" +  message, inner) { }
		protected BytebankException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}

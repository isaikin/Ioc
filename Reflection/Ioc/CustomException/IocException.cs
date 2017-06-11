using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.CustomException
{
	public class IocException : System.Exception
	{
		public IocException(string message) : base(message)
		{

		}

		public IocException(string message, Exception innerException) : base(message, innerException)
		{

		}

		public IocException() : base()
		{

		}
	}
}

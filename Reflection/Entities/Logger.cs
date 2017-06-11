using Ioc.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Export]
	public class Logger
	{
		public string Log()
		{
			return "Logger";
		}
	}
}

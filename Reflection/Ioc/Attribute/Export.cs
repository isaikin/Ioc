using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc.Attribute
{
	public class Export: System.Attribute
	{
		public Type Type { get; set; }

		public Export()
		{
			this.Type = null;
		}
		public Export(Type type)
		{
			this.Type = type;
		}
	}
}

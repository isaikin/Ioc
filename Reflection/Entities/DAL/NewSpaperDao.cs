using Ioc.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DAL
{
	[ImportConstructor]
	public class NewSpaperDao: INewSpaperDao
	{
		public string GetValue()
		{
			return "NewSpaperDao";
		}
	}
}

using Entities.DAL;
using Entities.Interface;
using Ioc.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BLL
{
	public class NewSpaperBLLProperty : INewSpaperBLLProperty
	{
		[Import]
		public INewSpaperDao NewSpaperDao { get; set; }

		[Import]
		public INewSpaperIssueDao NewSpaperIssueDao { get; set; }
		public string Show()
		{
			return this.NewSpaperDao.GetValue() + this.NewSpaperIssueDao.GetValue();
		}
	}
}

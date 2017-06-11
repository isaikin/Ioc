using Entities.DAL;
using Ioc.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BLL
{
	[Export(typeof(INewSpaperBLLAttribyte))]
	public class NewSpaperBLLAttribyte: INewSpaperBLLAttribyte
	{
		[Import]
		public INewSpaperDao NewSpaperDao { get; set; }

		[Import]
		public INewSpaperIssueDao NewSpaperIssueDao { get; set; }
		public string Show()
		{
			return this.NewSpaperDao.GetValue() + this.NewSpaperIssueDao.GetValue() + "NewSpaperBLLAttribyte";
		}
	}
}

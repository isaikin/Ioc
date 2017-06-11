using Entities.DAL;
using Entities.Interface;
using Ioc.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[ImportConstructor]
	public class NewSpaperBLL: INewSpaperBLL
	{
		private readonly INewSpaperDao newSpaperDao;
		private readonly INewSpaperIssueDao newSpaperIssueDao;
		public NewSpaperBLL(INewSpaperDao newSpaperDao, INewSpaperIssueDao newSpaperIssueDao)
		{
			this.newSpaperDao = newSpaperDao;
			this.newSpaperIssueDao = newSpaperIssueDao;
		}
		public string Show()
		{
			return this.newSpaperDao.GetValue() + this.newSpaperIssueDao.GetValue();
		}
    }
}

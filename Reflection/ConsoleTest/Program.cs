using Entities;
using Entities.BLL;
using Entities.DAL;
using Entities.Interface;
using Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var contaner = new Container();

			//contaner.AddType<INewSpaperBLL, NewSpaperBLLProperty>();
			//contaner.AddType<INewSpaperDao, NewSpaperDao>();
			//contaner.AddType<INewSpaperIssueDao, NewSpaperIssueDao>();
			//contaner.AddType(typeof(Logger));
			//contaner.AddType(typeof(NewSpaperBLLAttribyte));


			var ass = Assembly.GetExecutingAssembly();
			contaner.AddAssembly(ass);
			var temp = contaner.CreateInstance<INewSpaperBLL>();

			Console.WriteLine(temp.Show());
		}
	}
}

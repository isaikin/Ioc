using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
	public class Constr : System.Attribute
	{
	}
	public class Cal:ICal
	{
		private int c;
		[Constr]
		public Cal(int c)
		{
			this.c = c;
		}

		public int Sum(int b)
		{
			return c + b;
		}
	}
	class Program
	{
		
		static void Main(string[] args)
		{
			Ioc cont = new Ioc();
			var y = cont.Get<ICal>();
			   Type t = typeof(Cal);
			foreach (var item in t.GetConstructors()) 
			{
				var r = item.GetCustomAttributesData();


				if (r[0].AttributeType == typeof(Constr))
				{
					foreach (var param in item.GetParameters())
					{
						Console.WriteLine(param);
					}
					//Activator.CreateInstance(t);
				}
			}
			
		}
	}
}

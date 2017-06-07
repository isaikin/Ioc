using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
	public class Ioc
	{
		private Dictionary<string, RegisterType> collection = new Dictionary<string, RegisterType>();

		private Dictionary<string, object> obj = new Dictionary<string, object>();
		public void Register<I, C>(I interfac, C thisClass) where C : I
		{
			collection.Add(typeof(I).Name, new RegisterType { Type = typeof(C), SingleTone = false });
		}

		public I Get<I>() where I:class
		{
			var temp = collection[typeof(I).Name];

			var ctor = temp.Type.GetConstructors().FirstOrDefault(item => item.GetCustomAttributesData().FirstOrDefault(ctor1 => ctor1.AttributeType == typeof(Constr)) != null);

			var tempparam = new List<object>();
			var param = ctor.GetParameters();
			if (param.Length == 0)
			{
				foreach (var item in ctor.GetParameters())
				{
					if (obj.ContainsKey(item.ParameterType.Name))
					{
						tempparam.Add(obj[item.ParameterType.Name]);
					}
					else
					{
						var tempvalue = item.GetType().GetInterfaces().FirstOrDefault(x => collection.ContainsKey(x.Name));

						var tempo = this.Get<tempvalue.UnderlyingSystemType>();
						this.obj.Add(intr.Name,  );
					}
				}
			}

			return default(I);
		}
	}
}

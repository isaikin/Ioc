using Ioc.Attribute;
using Ioc.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Ioc
{
	public class Container
	{
		#region [fields]

		private Dictionary<Type, Type> registration = new Dictionary<Type, Type>();

		#endregion [fields]

		#region [methods]
		public void AddType(Type value)
		{
			var interfaceValue = GetInterfaceExport(value);

			if (interfaceValue == null)
			{
				AddType(value, value);
				return;
			}

			AddType(interfaceValue, value);
		}
		public void AddType<T>()
		{
			this.AddType(typeof(T));
		}

		public void AddType(Type interfaceValue, Type classValue)
		{
			if (registration.ContainsKey(interfaceValue))
			{
				throw new IocException("Type already registered");
			}

			this.registration.Add(interfaceValue, classValue);
		}

		public void AddType<I, C>()
			where C : I
		{
			AddType(typeof(I), typeof(C));
		}
		public T CreateInstance<T>()
		{
			return (T)this.CreateInstance(typeof(T));
		}
		public object CreateInstance(Type value)
		{
			if (!this.registration.ContainsKey(value))
			{
				throw new IocException($"{value.Name} Type not registered");
			}

			var type = this.registration[value];

			if (IsImportConstructor(type))
			{
				var constructors = type.GetConstructors();

				if (constructors.Count() != 1)
				{
					throw new IocException("Type contains more than one constructor");
				}

				List<object> parametrs = new List<object>();

				foreach (var item in constructors.First().GetParameters())
				{
					parametrs.Add(this.CreateInstance(item.ParameterType));
				}

				if (parametrs.Count == 0)
				{
					return Activator.CreateInstance(type);
				}

				return Activator.CreateInstance(type, parametrs.ToArray());
			}

			var properties = type.GetProperties();
			var result = Activator.CreateInstance(type);

			foreach (var property in properties)
			{
				if (IsAttributeImport(property))
				{
					property.SetValue(result, this.CreateInstance(property.PropertyType));
				}
			}

			return result;
		}

		public void AddAssembly(Assembly value)
		{
			foreach (var item in value.DefinedTypes)
			{
				this.AddType(item);
			}

			foreach (var item in value.GetReferencedAssemblies())
			{
				var ass = Assembly.Load(item);

				foreach (var type in ass.DefinedTypes)
				{
					foreach (var interfaceType in type.GetInterfaces())
					{
						if (!this.registration.ContainsKey(interfaceType))
						{
							this.AddType(interfaceType,type);
						}
					}
				}

			}
			
		}

		#endregion [/methods]

		#region [private methods]
		private bool IsAttributeImport(PropertyInfo property)
		{
			return property.GetCustomAttributesData().Any(attribute => attribute.AttributeType == (typeof(Import)));
		}
		private bool IsImportConstructor(Type type)
		{
			return type.GetCustomAttributesData().Any(attribute => attribute.AttributeType == (typeof(ImportConstructor)));
		}
	
		private Type GetInterfaceExport(Type value)
		{
			var interfaceValue = value.GetCustomAttribute<Export>();

			return interfaceValue != null
				? interfaceValue.Type
				: null;
		}

		#endregion [/private methods]
	}
}

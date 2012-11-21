using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public class InstanceTypeHierarchyAsText : TypeHierarchyAsText
	{

		public InstanceTypeHierarchyAsText(object instance) : base(null)
		{
			this.instance = instance;
		}

		protected object instance;

		public static string GetInstanceTypeHierarchyAsText(object instance)
		{
			String result = null;
			if (instance != null)
				result = GetTypeHierarchyAsText(instance.GetType());
			else
				result = "Null instance type hierarchy";
			return result;
		}

		public override string ToString()
		{
			return GetInstanceTypeHierarchyAsText(instance);
		}

	}

}

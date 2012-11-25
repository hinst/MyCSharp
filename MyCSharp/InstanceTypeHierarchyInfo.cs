using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace MyCSharp
{

	public class InstanceTypeHierarchyInfo : TypeHierarchyInfo
	{

		Logger log = LogManager.GetCurrentClassLogger();

		public InstanceTypeHierarchyInfo(object instance) : base(null)
		{
			this.instance = instance;
		}

		protected object instance;

		protected string GetInstanceTypeHierarchyAsText()
		{
			String result = null;
			if (instance != null)
			{
				type = instance.GetType();
				log.Debug(type.ToString());
				result = GetTypeHierarchyAsText();
			}
			else
				result = "Null instance type hierarchy";
			return result;
		}

		public override string ToString()
		{
			return GetInstanceTypeHierarchyAsText();
		}

	}

}

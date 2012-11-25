using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace MyCSharp
{

	public class TypeHierarchyInfo
	{

		Logger logger = LogManager.GetCurrentClassLogger();

		public TypeHierarchyInfo(Type type)
		{
			this.type = type;
		}

		protected Type type;

		protected string GetTypeHierarchyAsText() 
		{
			var text = new StringBuilder();
			if (type != null)
			{
				while (true)
				{
					text.Append(type.FullName);
					type = type.BaseType;
					if (type != null)
						text.AppendLine();
					else
						break;
				}
			}
			else
			{
				logger.Debug("nth");
				text.Append("Null type hierarchy");
			}
			return text.ToString();
		}

		public override string ToString()
		{
			return GetTypeHierarchyAsText();
		}

	}

}

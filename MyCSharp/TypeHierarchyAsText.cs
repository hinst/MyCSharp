using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public class TypeHierarchyAsText
	{

		public TypeHierarchyAsText(Type type)
		{
			this.type = type;
		}

		protected Type type;

		public static string GetTypeHierarchyAsText(Type type)
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
				text.Append("Null type hierarchy");
			return text.ToString();
		}

		public override string ToString()
		{
			return GetTypeHierarchyAsText(type);
		}

		// this one implicitly converst to string
		public static implicit operator String(TypeHierarchyAsText instance)
		{
			return "";
			//return instance.ToString();
		}

	}

}

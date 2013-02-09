using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class IsHelper
	{

		public static bool IsSubtype(this Type type, Type baseType)
		{
			return type.Equals(baseType) || type.IsSubclassOf(baseType);
		}

		public static bool Is(this object o, Type type)
		{
			return o.GetType().IsSubtype(type);
		}

	}

}

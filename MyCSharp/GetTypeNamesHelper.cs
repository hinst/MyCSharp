using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class GetTypeNamesHelper
	{

		public static string[] GetTypeNames(this Type[] types)
		{
			return types.Select(type => type.Name).ToArray();
		}

	}

}

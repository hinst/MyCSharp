using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class GetTypesHelper
	{

		public static Type[] GetTypes(this object[] objects)
		{
			Type[] types = objects.Select(arg => arg.GetType()).ToArray();
			return types;
		}

	}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class ObjectNameHelper
	{

		// with the possibility of extracting Name property from WPF visual elements
		public static string GetSensibleName(this object o)
		{
			if (o == null)
				return "null_object";
			return "";
		}

	}

}

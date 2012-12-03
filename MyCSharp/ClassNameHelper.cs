using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCSharp
{

	public static class ClassNameHelper
	{

		public static string GetFullClassName(this object x)
		{
			const string NullClassName = "Null";
			string result;
			if (x != null)
			{
				Type type = x.GetType();
				result = type.FullName;
			}
			else
				result = NullClassName;
			return result;
		}

	}

}

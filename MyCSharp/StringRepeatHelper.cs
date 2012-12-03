using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class StringRepeatHelper
	{

		public static string Replicate(this string stringToRepeat, int count)
		{
			var result = new StringBuilder(stringToRepeat.Length * count);
			for (int i = 0; i < count; ++i)
				result.Append(stringToRepeat);
			return result.ToString();
		}

	}

}

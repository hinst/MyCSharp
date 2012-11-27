using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class StringBuilderExtension
	{

		public static void AppendStrings(this StringBuilder stringBuilder, params object[] strings)
		{
			for (int i = 0; i < strings.Length; ++i)
				stringBuilder.Append(strings[i]);
		}

	}

}

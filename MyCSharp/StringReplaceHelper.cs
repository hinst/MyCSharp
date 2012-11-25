using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class StringReplaceHelper
	{

		static void ReplaceThis(this string s, string old, string neww)
		{
			s = s.Replace(old, neww);
		}

	}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class Cycle
	{

		// returns true -> breaks cycle
		public delegate void Function(int index);

		public static void Forward(int startIndex, int lastIndex, Function function)
		{
			for (int i = startIndex; i < lastIndex; ++i)
			{
				function(i);
			}
		}

		// returns true -> breaks cycle
		public delegate bool BreakableFunction(int index);

		public static void Forward(int startIndex, int lastIndex, BreakableFunction function)
		{
			for (int i = startIndex; i < lastIndex; ++i)
			{
				bool result = function(i);
				if (!result)
					break;
			}
		}

	}

}

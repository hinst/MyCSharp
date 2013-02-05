using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class ForEach
	{

		public static int MatchingType<T>(System.Collections.IEnumerable enumerable, Action<T> action) where T: class
		{
			int count = 0;
			foreach (object item in enumerable)
			{
				var itemOfT = item as T;
				if (itemOfT != null)
					action(itemOfT);
			}
			return count;
		}

	}

}

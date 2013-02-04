using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class AutoCreateField
	{

		public static T Get<T>(ref T item, Func<T> create)
		{
			if (null == item)
				item = create();
			return item;
		}

	}

}

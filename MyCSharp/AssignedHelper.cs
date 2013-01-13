using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class AssignedHelper
	{

		public static bool Assigned(this object instance)
		{
			return instance != null;
		}

	}

}

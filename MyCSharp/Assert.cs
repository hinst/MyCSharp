using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public class Assert
	{

		public Assert(bool condition, Exception e)
		{
			if (!condition)
				throw e;
		}

	}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class StringReplaceHelper
	{

		static void Replace(this D o, string stringToModify, string oldString, string newString)
		{
			stringToModify = stringToModify.Replace(oldString, newString);
		}

	}

}

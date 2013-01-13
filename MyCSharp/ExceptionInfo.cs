using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyCSharp
{

    public static class ExceptionInfoHelper
    {

		public static string GetExceptionDescriptionAsText(this Exception exception, string ident = "")
		{
			var text = new StringBuilder();
			if (exception != null)
			{
				text.AppendStrings(
					"Exception: ", exception.GetFullClassName(), Environment.NewLine,
					"Message: ", exception.Message.Ident(" ", 1), Environment.NewLine,
					"Stack trace: \n", exception.StackTrace.Unident()
				);
				if (exception.InnerException != null)
				{
					text.AppendLine();
					text.Append(
						exception.InnerException.GetExceptionDescriptionAsText(ident: " ")
					);
				}
			}
			else
			{
				text.Append("Null exception");
			}
			return text.ToString().Ident(ident);
		}

    }

}

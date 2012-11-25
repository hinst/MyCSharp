using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyCSharp
{

    public class ExceptionInfo
    {

        public ExceptionInfo(Exception e)
        {
			exception = e;
        }

        protected Exception exception;

		public string ToString(string ident)
		{
			var text = new StringBuilder();
			text.AppendLine("!Exception: " + exception.GetFullClassName());
			text.AppendLine("+Message: " + exception.Message.Ident("|", 1));
			var stackTraceText = exception.StackTrace;
			D.o.Apply(ref stackTraceText, "Unident");
			text.Append("+Stack trace: " + stackTraceText.Ident("|", 1));
			if (exception.InnerException != null)
			{
				text.AppendLine();
				text.Append(
					new ExceptionInfo(exception.InnerException).ToString(" ")
				);
			}
			return text.ToString().Ident(ident);
		}

        public override string ToString()
        {
			return this.ToString("");
        }

    }

}

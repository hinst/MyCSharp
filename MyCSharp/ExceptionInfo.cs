using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

    public class ExceptionInfo
    {

        public ExceptionInfo(Exception e)
        {
        }

        protected Exception exception;

        public override string ToString()
        {
            var text = new StringBuilder();
            text.AppendLine("Exception: " + exception.GetFullClassName());
            return text.ToString();
        }

    }

}

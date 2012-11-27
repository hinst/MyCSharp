using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class MemberExpresssionHelper
	{

		public static string GetVariableName<T>(this Expression<Func<T>> expression)
		{
			Assert.IsMemberExpression(expression);
			return GetVariableName((MemberExpression)expression.Body);
		}

		public static string GetVariableName(this MemberExpression expression)
		{
			return expression.Member.Name;
		}

		public static string GetVariableName<T>(this D o, Expression<Func<T>> expression)
		{
			return expression.GetVariableName();
		}

		public static string AppendVariableName<T>(this string text, Expression<Func<T>> expression)
		{
			return text + expression.GetVariableName();
		}

	}

}

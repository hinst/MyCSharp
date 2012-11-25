using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class VariableNameExtractor
	{

		public static string GetVariableName<T>(Expression<Func<T>> expression)
		{
			new Assert(expression != null, new ArgumentNullException("expression"));
			new Assert(expression.Body != null, new ArgumentNullException("expression"));
			new Assert(
				expression.Body is MemberExpression, 
				new InvalidCastException("expression.Body is not " + typeof(MemberExpression).GetFullClassName())
			);
			var body = (MemberExpression)expression.Body;
			return body.Member.Name;
		}

		public static string GetVariableName<T>(this D o, Expression<Func<T>> expression)
		{
			return GetVariableName(expression);
		}

		public static string AppendVariableName<T>(this string o, Expression<Func<T>> expression)
		{
			return GetVariableName(expression);
		}

	}

}

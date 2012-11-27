using System;
using System.Linq;
using System.Linq.Expressions;

namespace MyCSharp
{

	public static class GetMemberExpressionValueHelper
	{

		public static object GetValue(this MemberExpression member)
		{
			var objectMember = Expression.Convert(member, typeof(object));
			var getterLambda = Expression.Lambda<Func<object>>(objectMember);
			var getter = getterLambda.Compile();
			return getter();
		}

	}

}

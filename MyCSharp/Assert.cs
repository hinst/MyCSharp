using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class Assert
	{

		static Assert()
		{
			behaviour = DefaultBehaviour;
		}

		public enum Behaviour { ThrowException, LogError }

		public static Behaviour[] DefaultBehaviour
		{
			get
			{
				return 
					new Behaviour[] 
					{ 
						Behaviour.ThrowException
					};
			}
		}

		public static Behaviour[] behaviour;

		public static void Condition(bool condition, Func<Exception> exception)
		{
			if (false == condition)
				if (behaviour.Contains(Behaviour.ThrowException))
					throw exception();
		}

		public static void IsMemberExpression<T>(Expression<Func<T>> expression)
		{
			Assert.Condition(expression != null, () => new ArgumentNullException("expression"));
			Assert.Condition(expression.Body != null, () => new ArgumentNullException("expression"));
			Assert.Condition(
				expression.Body is MemberExpression,
				() => new InvalidCastException("expression.Body is not " + typeof(MemberExpression).GetFullClassName())
			);
		}

		public static void Is<T>(object instance)
		{
			NotNull(instance);
			Condition(instance is T, () => new InvalidCastException(""));
		}

		public static void NotNull(object objectToCheck)
		{
			Condition(objectToCheck != null, () => new ArgumentNullException());
		}

		public static void NotCritical(Exception e)
		{
			Condition(false == e.IsCritical(), () => e is CriticalException ? e : new CriticalException(inner: e) );
		}

	}

}

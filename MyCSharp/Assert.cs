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
		}

		public enum Behaviour { ThrowException, WriteDebug }

		public static Behaviour[] DefaultBehaviour
		{
			get
			{
				return 
					new Behaviour[] 
					{ 
						Behaviour.ThrowException,
					};
			}
		}

		public static Behaviour[] behaviour = DefaultBehaviour;

		public static void Condition(bool condition, Func<Exception> exception)
		{
			if (behaviour.Contains(Behaviour.WriteDebug))
				Console.WriteLine("Asserting condition: " + condition);
			if (false == condition)
				if (behaviour.Contains(Behaviour.ThrowException))
				{
					if (behaviour.Contains(Behaviour.WriteDebug))
						Console.WriteLine("Throwing exception " + exception.GetFullClassName() + "\"");
					throw exception();
				}
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
			Assigned(instance);
			Condition(instance is T, () => new InvalidCastException(""));
		}

		private const string AssignedAssertionFailedExceptionMessage = "Assertion failed";

		public static void Assigned(object objectToCheck)
		{
			if (DefaultBehaviour.Contains(Behaviour.WriteDebug))
				Console.WriteLine("Assert.Assigned \"" + objectToCheck + "\", " + (objectToCheck != null));
			Condition(objectToCheck != null, () => new NullReferenceException(AssignedAssertionFailedExceptionMessage));
		}

		public static void NotCritical(Exception e)
		{
			Condition(false == e.IsCritical(), () => e is CriticalException ? e : new CriticalException(inner: e) );
		}

	}

}

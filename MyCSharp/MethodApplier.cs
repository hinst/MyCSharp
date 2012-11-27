using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MyCSharp
{

	public static class MethodApplier
	{

		public static T ApplyMethod<T>(ref T objectToModify, string methodName, params object[] parameters)
		{
			Assert.NotNull(objectToModify);
			var method = objectToModify.GetMethod(methodName, parameters);
			objectToModify = (T)method.Invoke(objectToModify, parameters);
			return objectToModify;
		}

		public static T Apply<T>(this D o, ref T objectToModify, string methodName, params object[] parameters)
		{
			return ApplyMethod(ref objectToModify, methodName, parameters);
		}

	}

}

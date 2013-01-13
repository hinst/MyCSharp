using System;
using System.Reflection;
using System.Collections.Generic;

namespace MyCSharp
{

	public class GetMethodException : System.Exception
	{

		public GetMethodException(string message = null, System.Exception inner = null)
			:
			base
			(
				"Could not get method. Reason: "
					+ (message ?? (inner == null ? "unknown" : "see inner exception"))
					+ ".",
				inner
			)
		{
		}

	}

	public static class GetMethodHelper
	{

		public static MethodInfo GetObjectMethod(this object objct, string methodName, params object[] parameters)
		{
			if (objct == null)
				throw new GetMethodException(inner: new ArgumentNullException("objct"));
			if (methodName == null)
				throw new GetMethodException(inner: new ArgumentNullException("methodName"));
			if (parameters == null)
				throw new GetMethodException(inner: new ArgumentNullException("parameters"));
			MethodInfo method;
			try
			{
				method = objct.GetType().GetMethod(methodName, parameters.GetTypes());
			}
			catch (Exception e)
			{
				throw new GetMethodException(inner: e);
			}
			if (method == null)
				throw new GetMethodException("not found");
			return method;
		}

	}

}

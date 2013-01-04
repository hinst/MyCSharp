using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public static class GetMethodDeclarationHelper
	{

		public class Exception: System.Exception
		{
		}

		public const int MaxMethodDeclarationLength = 1000;

		public static string DeclareMethod(this D o, Type returnType, Type type, string methodName, params Type[] parameters)
		{
			Assert.Assigned(returnType);
			Assert.Assigned(type);
			Assert.Assigned(parameters);
			return DeclareMethod(returnType.Name, type.Name, methodName, parameters.GetTypeNames());
		}

		public static string DeclareMethod(string returnType, string type, string methodName, params string[] parameters)
		{
			Assert.Assigned(type);
			Assert.Assigned(methodName);
			Assert.Assigned(parameters);
			var text = new StringBuilder(MaxMethodDeclarationLength);
			if (type != null)
			{
				text.AppendStrings(returnType, " ", type, ".", methodName, "(", String.Join(", ", parameters), ")");
			}
			else
				throw new Exception();
			return text.ToString();
		}

	}

}

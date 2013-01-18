using System;
using System.Linq;
using System.Reflection;

namespace MyCSharp
{

	public class ApplicationClassRunner
	{

		public const string ApplicationClassConfigurationKey = "ApplicationClass";

		public const string MainMethodName = "Main"; 
		
		private static Type[] mainMethodParameters = new Type[] { typeof(string[]) };

		public static Type[] MainMethodParameters 
		{
			get
			{
				return mainMethodParameters;
			}
		}

		public const bool ConsoleOutputEnabled = true;

		public class Exception : System.Exception 
		{

			public Exception(string message)
				: base(message)
			{
			}

		};

		protected static void WriteLine(string text)
		{
			if (ConsoleOutputEnabled)
				Console.WriteLine(text);
		}

		public static int RunMain(Type type, string[] arguments)
		{
			int result = -1;
			Assert.Assigned(type);
			try
			{
				var fullMethodName = type.FullName + "." + MainMethodName;
				WriteLine("[ ? ] Now searching " + fullMethodName + "...");
				MethodInfo main = type.GetMethod(MainMethodName, MainMethodParameters);
				Assert.Condition(
					main != null, 
					() => new Exception("Method '" + fullMethodName + "' not found")
				);
				Assert.Condition(
					main.IsStatic,
					() => new Exception("Method " + fullMethodName + " is not static")
				);
				WriteLine("[ > ] Now running " + type.FullName + ".Main...");
				var resultObject = main.Invoke(null, new object[] { arguments });
				WriteLine("[ X ] Execution " + fullMethodName + " result: " 
					+ (resultObject.Assigned() ? resultObject.ToString() : "none"));
				result = resultObject is int ? (int)resultObject : 0;
			}
			catch (Exception exception)
			{
				WriteLine("[ ! ] Run Main failed:\n" + exception.GetExceptionDescriptionAsText());
				Assert.NotCritical(exception);
			}
			return result;
		}

		public static int RunMain(string typeName, string[] arguments)
		{
			int result = -1;
			try
			{
				Type type = Type.GetType(typeName, true);
				Assert.Condition(
					type != null,
					() => new Exception("Type '" + typeName + "' not found.")

				);
				result = RunMain(type, arguments);
			}
			catch (Exception e)
			{
				WriteLine(e.GetExceptionDescriptionAsText());
			}
			return result;
		}

		public static int Main(string[] arguments)
		{
			try
			{
				Assert.Assigned(arguments);
				Assert.Condition(
					arguments.Length >= 1,
					() => new Exception("agruments.Length is 0; class to run is unspecified")
				);
			}
			catch (Exception exception)
			{
				WriteLine("Run Main failed:\n" 
					+ exception.GetExceptionDescriptionAsText());
				return -1;
			}
			return 
				RunMain(
					arguments[0], 
					arguments.Skip(1).ToArray()
				);
		}

	}

}

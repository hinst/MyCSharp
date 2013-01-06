using System;

namespace MyCSharp
{

	public class TestApplicationManager
	{

		public static void Run<T>(TestApplication testApplication)
		{
			var testApplicationManager = new TestApplicationManager(testApplication);
		}

		public TestApplicationManager(TestApplication testApplication)
		{
			this.testApplication = testApplication;
		}

		protected TestApplication testApplication;

		public void Run()
		{
			try
			{
				testApplication.Run();
			}
		}

	}

}

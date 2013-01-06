using System;

using NLog;

namespace MyCSharp
{

	public class TestApplicationManager
	{

		public static void Run<T>(TestApplication testApplication)
		{
			new TestApplicationManager(testApplication).Run();
		}

		private Logger log = LogManager.GetCurrentClassLogger();

		public TestApplicationManager(TestApplication testApplication)
		{
			this.testApplication = testApplication;
		}

		protected TestApplication testApplication;

		public bool Run()
		{
			bool result = false;
			try
			{
				log.Info("[ > ] Now running '" + testApplication.GetFullClassName() + "'...");
				result = testApplication.Run();
				log.Info("[ X ] Now exiting...");
			}
			catch (Exception exception)
			{
				log.Fatal(exception.GetExceptionDescriptionAsText());
				Assert.NotCritical(exception);
			}
			return result;
		}

	}

}

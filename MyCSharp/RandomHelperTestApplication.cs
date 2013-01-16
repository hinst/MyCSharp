using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public class RandomHelperTestApplication
	{

		public static void Main(string[] arguments)
		{
			var application = new RandomHelperTestApplication();
			application.Run();
		}

		public void Run()
		{
			Random random = new Random(DateTime.Now.Millisecond);
			TestNextDouble(random);
		}

		public void WriteLine(String text)
		{
			Console.WriteLine(text);
		}

		protected void TestNextDouble(Random random, double min, double max)
		{
			Func<double, string> formatDouble = x => String.Format("{0:+0.00;-0.00;00.00}", x);
			var randomValue = random.NextDouble(min, max);
			bool check = (min < randomValue && randomValue < max);
			WriteLine(
				formatDouble(min)
				+ " < " + formatDouble(randomValue)
				+ " < " + formatDouble(max)
				+ " = " + check)
			;
		}

		protected void TestNextDouble(Random random)
		{
			WriteLine(" * " + MethodBase.GetCurrentMethod().Name + " * ");
			const int TestCount = 3;
			for (int i = 0; i < TestCount; ++i)
				TestNextDouble(random, 5 * random.NextDouble(), 10 * random.NextDouble());
			for (int i = 0; i < TestCount; ++i)
				TestNextDouble(random, 0, 300);
			TestNextDouble(random, 0, 0);
			TestNextDouble(random, 0, -1);
		}

	}

}

using System;
using System.Windows;

namespace MyTest
{

	public class TestRef
	{

		public static void Main(string[] arguments)
		{
			var application = new TestRef();
			application.Run();
		}

		public void Run()
		{
			for (int i = 0; i < things.Length; ++i)
			{
				Do(things[i]);
			}
		}

		public class Thing
		{

			public Thing()
			{
			}


			public override string ToString()
			{
				return "";
			}
		}

		protected static Thing[] things = new Thing[2];

		public void Do(Thing thing)
		{
			if (thing != null)
				Console.WriteLine("FFFUUU");
		}

	}

}





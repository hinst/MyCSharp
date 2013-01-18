using System;

namespace MyCSharp
{

	public static class RandomHelper
	{

		public static double NextDouble(this Random random, double min, double max)
		{
			return min + (max - min) * random.NextDouble();
		}

		public static double NextSignedDouble(this Random random, double min, double max)
		{
			return NextSign(random, false) * NextDouble(random, min, max);
		}

		public static int NextSign(this Random random, bool allowZero)
		{
			int 
				max = allowZero ? 3 : 2, 
				result = 0;
			switch (random.Next(max))
			{
				case 0:
					result = -1;
					break;
				case 1:
					result = 1;
					break;
			}
			return result;
		}

	}

}

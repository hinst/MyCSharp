using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Reflection;

using NLog;

using MB.Tools;

using MyCSharp;


namespace MyWPF
{

	public class PointBouncer
	{

		protected Logger log = LogManager.GetCurrentClassLogger();

		public PointBouncer()
		{
			random = new Random(DateTime.Now.Millisecond);
		}

		protected class Data
		{

			public Data()
			{
			}

			protected Point speed;

			public Point Speed
			{
				get
				{
					if (speed == null)
						speed = new Point();
					return speed;
				}
				set
				{
					speed = value;
				}
			}

			protected static string pointMetaPropertyName;

			public static string PointMetaPropertyName
			{
				get
				{
					if (null == pointMetaPropertyName)
						pointMetaPropertyName = typeof(Data).FullName;
					return pointMetaPropertyName;
				}
			}

		}

		protected Random random;

		private Data GetData(Point point)
		{
			Data result = null;
			if (MetaPropertyExtender.HasMetaProperty(point, Data.PointMetaPropertyName))
				result = 
					(Data)
						MetaPropertyExtender.GetMetaProperty(
							point, Data.PointMetaPropertyName
						);
			else
			{
				result = new Data();
				MetaPropertyExtender.SetMetaProperty(
					point, Data.PointMetaPropertyName, result
				);
			}
			return result;
		}

		public string GetPointInfoAsText(Point point)
		{
			return "Point: " + point + "; speed: " + GetData(point).Speed;
		}

		public const double DefaultMaximalSpeedFraction = 0.1;

		public const double DefaultMinimalSpeedFraction = 0.01;

		public void SetRandomSpeed(Point point, Size areaSize)
		{
			GetData(point).Speed = 
				(
					new double[] { areaSize.Width, areaSize.Height }
				)
				.Select(
					(d) => new Point(d * DefaultMinimalSpeedFraction, d * DefaultMaximalSpeedFraction)
				)
				.Select(
					(p) => random.NextSignedDouble(p.X, p.Y)
				)
				.ToArray()
				.CreateWindowsPoint();
			log.Debug(MethodBase.GetCurrentMethod().Name + " routine completed;"
				+ "\tspeed is: " + GetData(point).Speed);
		}

		public void SetRandomPosition(ref Point point, Size areaSize)
		{
			var x = random.NextDouble(0, areaSize.Width);
			log.Debug(areaSize);
			point.X = x;
			var y = random.NextDouble(0, areaSize.Height);
			point.Y = y;
			//log.Debug(MethodBase.GetCurrentMethod().Name + " routine completed;"
			//	+ "  point is: " + point.ToString() + ";"
			//	+ "  x is: " + x + ", y is: " + y);
		}

		/// <summary>
		/// This method is supposed to be unused.
		/// </summary>
		/// <param name="point"></param>
		/// <param name="areaSize"></param>
		protected void SetRandomSpeedOldVersion(Point point, Size areaSize)
		{
			var data = GetData(point);
			data.Speed =
				new Point(
					random.NextDouble(
						areaSize.Width * DefaultMinimalSpeedFraction,
						areaSize.Width * DefaultMaximalSpeedFraction
					),
					random.NextDouble(
						areaSize.Height * DefaultMaximalSpeedFraction,
						areaSize.Height * DefaultMinimalSpeedFraction
					)
				);
		}

		public void BounceMove(ref Point point, Size areaSize, double interval)
		{
			log.Debug(" --- " + GetPointInfoAsText(point));
			var data = GetData(point);
			Point speed = data.Speed;
			if (point.X > areaSize.Width && speed.X > 0)
				speed.X = -speed.X;
			if (point.Y > areaSize.Height && speed.Y > 0)
				speed.Y = -speed.Y;
			if (point.X < 0 && speed.X < 0)
				speed.X = -speed.X;
			if (point.Y < 0 && speed.Y < 0)
				speed.Y = -speed.Y;
			point.X += speed.X * interval;
			point.Y += speed.Y * interval;
			data.Speed = speed;
			log.Debug("data.Speed = " + data.Speed + "; speed = " + speed);
			log.Debug(" +++ " + GetPointInfoAsText(point));
		}

	}

}

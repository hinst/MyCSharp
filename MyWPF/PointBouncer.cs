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

	public class Bouncer
	{

		protected Logger log = LogManager.GetCurrentClassLogger();

		public Bouncer()
		{
			random = new Random(DateTime.Now.Millisecond);
		}

		public class MovingPoint
		{

			public MovingPoint()
			{
			}

			public Point Position;

			public Point Speed;

			public override string ToString()
			{
				return Position.ToString() + ", " + Speed;
			}

		}

		protected Random random;

		public const double DefaultMaximalSpeedFraction = 0.1;

		public const double DefaultMinimalSpeedFraction = 0.01;

		public void SetRandomSpeed(ref Point speed, Size areaSize)
		{
			speed = 
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

		const bool LogDebugSetRandom = false;

		public void SetRandom(MovingPoint point, Size areaSize)
		{
			if (LogDebugSetRandom)
				#pragma warning disable 162
				log.Debug("Assert.Assigned(point)");
				#pragma warning restore 162
			Assert.Assigned(point);
			if (LogDebugSetRandom)
				#pragma warning disable 162
				log.Debug("Set random position");
				#pragma warning restore 162
			SetRandomPosition(ref point.Position, areaSize);
			if (LogDebugSetRandom)
				#pragma warning disable 162
				log.Debug("Set random speed");
				#pragma warning disable 162
			SetRandomSpeed(ref point.Speed, areaSize);
		}

		public void Move(MovingPoint x, Size areaSize, double interval)
		{
			if (x.Position.X > areaSize.Width && x.Speed.X > 0)
				x.Speed.X = -x.Speed.X;
			if (x.Position.Y > areaSize.Height && x.Speed.Y > 0)
				x.Speed.Y = -x.Speed.Y;
			if (x.Position.X < 0 && x.Speed.X < 0)
				x.Speed.X = -x.Speed.X;
			if (x.Position.Y < 0 && x.Speed.Y < 0)
				x.Speed.Y = -x.Speed.Y;
			x.Position.X += x.Speed.X * interval;
			x.Position.Y += x.Speed.Y * interval;
		}

	}

}

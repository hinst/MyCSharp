#region using System
using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Threading;
#endregion

#region using NLog
using NLog;
#endregion

#region using Mine
using MyCSharp;
#endregion

namespace MyWPF
{

	public class DrawingBox : UserControl
	{

		protected Logger log = LogManager.GetCurrentClassLogger();

		public DrawingBox()
		{
		}

		protected DispatcherTimer timer;

		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			Draw(drawingContext);
		}

		protected virtual void Draw(DrawingContext context)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="interval">milliseconds</param>
		public virtual void Start(int interval)
		{
			Assert.Condition(interval < 1000, () => new ArgumentException("Condition violated: interval < 1000"));
			if (timer == null)
			{
				timer = new DispatcherTimer(DispatcherPriority.Normal);
				timer.Interval = new TimeSpan(0, 0, 0, 0, interval);
				timer.Tick += HandleTimerTick;
			}
			timer.Start();
		}

		public bool Started
		{
			get
			{
				return timer != null;
			}
		}

		/// <summary>
		/// Returns current interval (millisecond)
		/// </summary>
		public int Interval
		{
			get
			{
				if (timer != null)
					return timer.Interval.Milliseconds;
				else
					return -1;
			}
			set
			{
				timer.Interval = new TimeSpan(0, 0, 0, 0, value);
			}
		}

		protected void Stop()
		{
			if (timer != null)
				timer.Stop();
		}

		protected void DemandRedraw()
		{
			InvalidateVisual();
		}

		protected void HandleTimerTick(object sender, EventArgs eventArgs)
		{
			DemandRedraw();
		}

	}

}

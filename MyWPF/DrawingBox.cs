#region using System
using System;
using System.Diagnostics;
using System.Windows;
using System.Globalization;
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

		private Logger log = LogManager.GetCurrentClassLogger();

		public DrawingBox()
		{
		}

		protected DispatcherTimer timer;

		protected Stopwatch renderStopwatch;

		protected int framesPerSecondCounter;

		protected int framesPerSecond;

		public int FramesPerSecond
		{
			get
			{
				return framesPerSecond;
			}
			private set
			{
				framesPerSecond = value;
				framesPerSecondAsTextCache = framesPerSecond.ToString();
			}
		}

		protected string framesPerSecondAsTextCache;

		private void EvaluateFramesPerSecond()
		{
			if (null == renderStopwatch)
				return; // seems like performance evaluating is disabled
			++framesPerSecondCounter;
			if (renderStopwatch.ElapsedMilliseconds > 1000)
			{
				FramesPerSecond = framesPerSecondCounter;
				renderStopwatch.Restart();
				framesPerSecondCounter = 0;
			}
		}

		protected Stopwatch sinceLastFrameStartedStopwatch;

		protected long sinceLastFrameStartedTime;

		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			if (Running)
			{
				sinceLastFrameStartedTime = sinceLastFrameStartedStopwatch.ElapsedMilliseconds;
				sinceLastFrameStartedStopwatch.Restart();
				Draw(drawingContext);

				EvaluateFramesPerSecond();

				if (DrawFramesPerSecondEnabled)
					DrawFramesPerSecond(drawingContext);
			}
		}

		protected bool drawFramesPerSecondEnabled;

		public bool DrawFramesPerSecondEnabled
		{
			get
			{
				return drawFramesPerSecondEnabled;
			}
			set
			{
				drawFramesPerSecondEnabled = value;
			}
		}

		protected Typeface framesPerSecondTypeface;

		protected Typeface FramesPerSecondTypeface
		{
			get
			{
				if (null == framesPerSecondTypeface)
					framesPerSecondTypeface = new Typeface("Consolas");
				return framesPerSecondTypeface;
			}
		}

		private Brush framesPerSecondBackgroundBrush;

		protected Brush FramesPerSecondBackgroundBrush
		{
			get
			{
				if (null == framesPerSecondBackgroundBrush)
				{
					Color color = Colors.Black;
					color.A = (byte)(color.A / 3);
					framesPerSecondBackgroundBrush = new SolidColorBrush(color);
				}
				return framesPerSecondBackgroundBrush;
			}
		}

		protected void DrawFramesPerSecond(DrawingContext context)
		{
			const double gap = 10;
			var text =
				new FormattedText(
					framesPerSecondAsTextCache ?? "?",
					CultureInfo.CurrentCulture,
					System.Windows.FlowDirection.LeftToRight,
					FramesPerSecondTypeface,
					10,
					QuickBrush.Black
				);
			var whereToDrawText = 
				new Point(
					ActualWidth - gap - gap - text.Width,
					gap + gap
				);
			Rect backgroundRectangle =
				new Rect(
					new Point(
						ActualWidth - gap - gap - text.Width - gap,
						gap
					),
					new Size(
						gap + text.Width + gap, 
						gap + text.Height + gap
					)
				);
			context.DrawText(text, whereToDrawText);
			context.DrawRectangle(FramesPerSecondBackgroundBrush, BlackPen.Instance, backgroundRectangle);
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
				timer = new DispatcherTimer(DispatcherPriority.Render);
				timer.Interval = new TimeSpan(0, 0, 0, 0, interval);
				timer.Tick += HandleTimerTick;
			}
			renderStopwatch = new Stopwatch();
			renderStopwatch.Start();
			framesPerSecondCounter = 0;
			sinceLastFrameStartedStopwatch = new Stopwatch();
			timer.Start();
		}

		public bool Started
		{
			get
			{
				return timer != null;
			}
		}

		public bool Running
		{
			get
			{
				bool result = timer != null;
				if (result)
					result &= timer.IsEnabled;
				return result;
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

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

using NLog;

using MyCSharp;

namespace MyWPF.TestDrawingBox
{

	public partial class TestDrawingBox : DrawingBox
	{

		private Logger log = LogManager.GetCurrentClassLogger();

		public TestDrawingBox()
			: base()
		{
			InitializeComponent();
			Loaded += LoadedEventHandler;
		}

		public const int DefaultUpdateInterval = 1000/40;
		//public const int DefaultUpdateInterval = ;

		public void LoadedEventHandler(object sender, RoutedEventArgs e)
		{
			log.Debug("Loaded...");
			CreateBouncingLines();
			Start(DefaultUpdateInterval);
			log.Debug("Loaded.");
		}

		public void LoadedEventHandlerSafe(object sender, RoutedEventArgs e)
		{
			try
			{
				LoadedEventHandler(sender, e);
			}
			catch (Exception exception)
			{
				log.Error("While executing " + MethodBase.GetCurrentMethod().Name + ":\n"
					+ exception.GetExceptionDescriptionAsText());
			}
		}

		/// <summary>
		/// Создаёт новую движущуюся линию и задаёт случайные значения для неё
		/// </summary>
		public Bouncer.MovingPoint[] NewRandomMovingLine()
		{
			var result = new Bouncer.MovingPoint[2];
			for (int i = 0; i < result.Length; ++i)
			{
				result[i] = new Bouncer.MovingPoint();
				bouncer.SetRandom(result[i], this.GetActualSize());
			}
			return result;
		}

		protected const bool LogCreateMovingLinesProgress = true;

		public void CreateBouncingLines()
		{
			log.Debug("CreateMovingLines...");
			for (int i = 0; i < bouncingLines.Length; ++i)
			{
				bouncingLines[i] = NewRandomMovingLine();
			}
		}

		public override void Start(int interval)
		{
			log.Debug("Now starting...");
			drawFramesPerSecondEnabled = true;
			base.Start(interval);
		}

		public bool EnableLogOnRender = false;

		protected override void OnRender(DrawingContext drawingContext)
		{
			if (EnableLogOnRender)
				log.Debug("OnRender...");
			base.OnRender(drawingContext);
		}

		public const bool DrawCrossEnabled = false;

		public const bool DrawDebugRectangleEnabled = false;

		protected override void Draw(DrawingContext context)
		{
			base.Draw(context);
			if (DrawCrossEnabled)
				DrawCross(context);
			if (DrawDebugRectangleEnabled)
				DrawRectangleDebugVersion(context);
			DrawAnimations(context);
		}

		protected void DrawAnimations(DrawingContext context)
		{
			foreach (Bouncer.MovingPoint[] line in bouncingLines)
				DrawLine(context, line);
			foreach (Bouncer.MovingPoint[] line in bouncingLines)
				BounceLine(line);
		}

		protected void DrawCross(DrawingContext context)
		{
			Rect cross = Rect.Inflate(new Rect(this.GetActualSize()), -10, -10);
			context.DrawLine(BlackPen.Instance, cross.TopLeft, cross.BottomRight);
			context.DrawLine(BlackPen.Instance, cross.BottomLeft, cross.TopRight);
		}

		protected void DrawRectangleDebugVersion(DrawingContext context)
		{
			Rect rectangle = new Rect(10, 10, 20, 20);
			context.DrawRectangle(Brushes.Black, BlackPen.Instance, rectangle);
		}

		public const int CountOfLines = 100;

		protected Bouncer.MovingPoint[][] bouncingLines = new Bouncer.MovingPoint[CountOfLines][];

		protected Bouncer bouncer = new Bouncer();

		protected void DrawLine(DrawingContext context, Bouncer.MovingPoint[] line)
		{
			Assert.Assigned(line);
			context.DrawLine(BlackPen.Instance, line[0].Position, line[1].Position);
		}

		protected void BounceLine(Bouncer.MovingPoint[] line)
		{
			Cycle.Forward(
				0,
				line.Length,
				(i) =>
				{
					bouncer.Move(
						line[i],
						this.GetActualSize(),
						(double)sinceLastFrameStartedTime / 1000
					);
				}
			);
		}

	}

}

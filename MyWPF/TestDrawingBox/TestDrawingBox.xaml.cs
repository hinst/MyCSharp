using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

using NLog;

using MyCSharp;

namespace MyWPF.TestDrawingBox
{

	public partial class TestDrawingBox : DrawingBox
	{

		public TestDrawingBox()
			: base()
		{
			InitializeComponent();
			Loaded += LoadedEventHandler;
		}

		public void LoadedEventHandler(object sender, RoutedEventArgs e)
		{
			log.Debug("Loaded; size: " + this.GetSize());
			for (int i = 0; i < bouncingLine.Length; ++i)
			{
				bouncer.SetRandomSpeed(bouncingLine[i], this.GetSize());
				bouncer.SetRandomPosition(ref bouncingLine[i], this.GetSize());
			}
			Start(900);
		}

		public override void Start(int interval)
		{
			log.Debug("Now starting...");
			base.Start(interval);
		}

		public bool EnableLogOnRender = true;

		protected override void OnRender(DrawingContext drawingContext)
		{
			if (EnableLogOnRender)
				log.Debug("OnRender...");
			base.OnRender(drawingContext);
		}

		protected override void Draw(DrawingContext context)
		{
			base.Draw(context);
			//DrawCross(context);
			//DrawRectangleDebugVersion(context);
			DrawBouncingLine(context);
		}

		protected void DrawCross(DrawingContext context)
		{
			Rect cross = Rect.Inflate(new Rect(this.GetSize()), -10, -10);
			context.DrawLine(BlackPen.Instance, cross.TopLeft, cross.BottomRight);
			context.DrawLine(BlackPen.Instance, cross.BottomLeft, cross.TopRight);
		}

		protected void DrawRectangleDebugVersion(DrawingContext context)
		{
			Rect rectangle = new Rect(10, 10, 20, 20);
			context.DrawRectangle(BlackBrush.Instance, BlackPen.Instance, rectangle);
		}

		protected static Point[] bouncingLine = new Point[2];

		protected PointBouncer bouncer = new PointBouncer();

		protected void DrawBouncingLine(DrawingContext context)
		{
			context.DrawLine(BlackPen.Instance, bouncingLine[0], bouncingLine[1]);
			log.Debug(String.Join(" ", bouncingLine[0]));
			Cycle.Forward(
				0, 
				bouncingLine.Length, 
				(i) =>
					{
						bouncer.BounceMove(
							ref bouncingLine[i], 
							this.GetSize(), 
							(double)this.Interval / 1000
						); 
					}
			);
		}

	}

}

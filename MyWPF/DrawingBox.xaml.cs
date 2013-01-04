#region using System
	using System;
	using System.Windows.Media;
	using System.Windows.Controls;
	using System.Windows.Threading;
#endregion

namespace MyWPF
{

	public partial class DrawingBox : UserControl
	{

		public DrawingBox()
		{
			InitializeComponent();
		}

		protected DispatcherTimer timer;

		protected DispatcherTimer Timer
		{
			get
			{
				return Timer;
			}
		}

		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
		}

		public void Start()
		{
			if (Timer == null)
			{
				timer = new DispatcherTimer(DispatcherPriority.Normal);
				timer.Tick += HandleTimerTick;
			}
			Timer.Start();
		}

		protected void DemandRedraw()
		{
			this.InvalidateVisual();
		}

		protected void HandleTimerTick(object sender, EventArgs eventArgs)
		{
			DemandRedraw();
		}

	}

}

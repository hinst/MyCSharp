#region using System
using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Threading;
#endregion

using NLog;

namespace MyWPF
{

	public partial class DrawingBox : UserControl
	{

		protected Logger log = LogManager.GetCurrentClassLogger();

		public DrawingBox()
		{
			InitializeComponent();
		}

		protected DispatcherTimer timer;

		protected DispatcherTimer Timer
		{
			get
			{
				return timer;
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
				timer.Interval = new TimeSpan(0, 0, 0, 0, 40);
				timer.Tick += HandleTimerTick;
			}
			Timer.Start();
		}

		protected void Stop()
		{
			if (Timer != null)
				Timer.Stop();
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

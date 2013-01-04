#region using System
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#endregion
#region using NLog
using NLog;
#endregion
#region using Mine
using MyCSharp;
#endregion

namespace MyWPF
{

	public partial class WaitControl : UserControl
	{

		Logger log = LogManager.GetCurrentClassLogger();

		public WaitControl()
		{
			InitializeComponent();
		}

		public WaitControl(UIElement element)
		{
			Assert.Assigned(element);
			InitializeComponent();
			controlAdornerLayer = AdornerLayer.GetAdornerLayer(element);
			Assert.Assigned(controlAdornerLayer);
			theAdorner = new ControlAdorner(element, this);
			controlAdornerLayer.Add(theAdorner);
		}

		protected AdornerLayer controlAdornerLayer;

		protected ControlAdorner theAdorner;

	}

}

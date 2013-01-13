using System;
using System.Windows;

namespace MyWPF.TestDrawingBox
{

	public partial class DrawingBoxWindow : Window
	{

		public DrawingBoxWindow()
			: base()
		{
			InitializeComponent();
			DrawingBoxInstance.Start();
		}

		public void LoadedHandler(object sender, RoutedEventArgs eventArgs)
		{
		}

	}

}
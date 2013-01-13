using System;
using System.Windows;

namespace MyWPF.TestDrawingBox
{

	public partial class PresentationApplication : Application
	{

		public PresentationApplication()
			: base()
		{
			InitializeComponent();
		}

		public static void Main(string[] arguments)
		{
			var application = new PresentationApplication();
			application.Run();
		}

	}

}

using System;
using System.Windows;
using System.Windows.Threading;
using System.Text;

using MyCSharp;

using NLog;

namespace MyWPF.TestDrawingBox
{

	public partial class PresentationApplication : Application
	{

		protected Logger log = LogManager.GetCurrentClassLogger();

		public PresentationApplication()
			: base()
		{
			InitializeComponent();
			AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
			this.DispatcherUnhandledException += DispatcherUnhandledExceptionHandler;
		}

		private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
		{
			var text = new StringBuilder();
			text.AppendLine("UNHANDLED EXCEPTION");
			object exceptionObject = unhandledExceptionEventArgs.ExceptionObject;
			var exception = exceptionObject as Exception;
			if (exception != null)
				text.AppendLine( exception.GetExceptionDescriptionAsText() );
			else // ExceptionObject is not an Exception
				text.AppendLine( "Excepion Object: " + exceptionObject );
			log.Error(text.ToString());
		}

		private void DispatcherUnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs dispatcherUnhandledExceptionEventArgs)
		{
			var text = new StringBuilder();
			text.AppendLine("UNHANDLED EXCEPTION");
			var exception = dispatcherUnhandledExceptionEventArgs.Exception;
			text.AppendLine(exception.GetExceptionDescriptionAsText());
			log.Error(text.ToString());
		}

		public static void Main(string[] arguments)
		{
			var application = new PresentationApplication();
			application.Run();
		}

	}

}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using MyCSharp;

using MyWPF;

namespace MyWPF
{

	public class TextEditWindow : Window
	{

		public TextEditWindow Create(string title, string caption, string initialText)
		{
			Title = title;
			InitializeFace();
			Caption.Content = caption;
			Edit.Text = initialText;
			Width = DefaultSize.Width;
			//Height = DefaultSize.Height;
			return this;
		}

		protected Label caption;

		public Label Caption
		{
			get
			{
				return caption;
			}
		}

		protected TextBox edit;

		public TextBox Edit
		{
			get
			{
				return edit;
			}
		}

		protected static readonly Thickness DefaultMargin = new Thickness(3);

		protected static readonly Size DefaultSize = new Size(300, 130);

		protected void InitializeFace()
		{
			var stackPanel = new StackPanel();
			AddChild(stackPanel);

			caption = new Label();
			stackPanel.Children.Add(caption);

			edit = new TextBox();
			stackPanel.Children.Add(edit);

			stackPanel.Children.Add(CreateButtons());

			ForEach.MatchingType<FrameworkElement>(
				stackPanel.Children,
				element => element.Margin = DefaultMargin
			);
			UpdateLayout();
			Height = stackPanel.ActualHeight;
			Console.Write(Height);
		}

		protected Image CreateOkayButtonContent()
		{
			var image = new Image();
			image.Source = new BitmapImage(new Uri(@"pack://application:,,,/MyWPF;component/Images/SubmitBlack16.png"));
			return image;
		}

		protected Image CreateCancelButtonContent()
		{
			var image = new Image();
			image.Source = new BitmapImage(new Uri(@"pack://application:,,,/MyWPF;component/Images/UndoBlack16.png"));
			return image;
		}

		protected StackPanel CreateButtons()
		{
			var panel = new StackPanel();

			var okayButton = new Button();
			okayButton.Content = CreateOkayButtonContent();
			okayButton.Padding = DefaultMargin;
			okayButton.Click += okayButtonHandler;
			panel.Children.Add(okayButton);

			var cancelButton = new Button();
			cancelButton.Content = CreateCancelButtonContent();
			cancelButton.Padding = DefaultMargin;
			cancelButton.Click += cancelButtonHandler;
			panel.Children.Add(cancelButton);

			panel.Orientation = Orientation.Horizontal;
			panel.HorizontalAlignment = HorizontalAlignment.Center;
			ForEach.MatchingType<FrameworkElement>(
				panel.Children,
				element => element.Margin = DefaultMargin
			); 
			return panel;
		}

		void okayButtonHandler(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Close();
		}

		void cancelButtonHandler(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}
		public static string Perform(Window parent, string title, string caption, string initialText)
		{
			var window = new TextEditWindow().Create(title, caption, initialText);
			window.Owner = parent;
			window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			var dialogResult = window.ShowDialog();
			var result = dialogResult == true ? window.Edit.Text : null;
			return result;
		}

		static void window_Loaded()
		{
			throw new NotImplementedException();
		}

	}

}

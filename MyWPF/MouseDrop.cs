using System;
using System.Windows;
using System.Windows.Input;

namespace MyWPF
{

	public class MouseDrop
	{

		public void Create(Type target, Cursor cursor)
		{
			this.target = target;
			dropCursor = cursor;
		}

		public void Attach(FrameworkElement attachTo)
		{
			attachedTo = attachTo;
			attachedTo.Cursor = DropCursor;
			attachedTo.PreviewMouseDown += PreviewTargetMouseDown;
		}

		protected Type target;

		public Type Target
		{
			get
			{
				return target;
			}
		}

		protected Cursor dropCursor;

		public Cursor DropCursor
		{
			get
			{
				return dropCursor;
			}
		}

		protected FrameworkElement attachedTo;

		public FrameworkElement AttachedTo
		{
			get
			{
				return attachedTo;
			}
		}

		/// <summary>
		/// Previews mouse down events for the Target
		/// Left click = drop
		/// Right click = cancel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void PreviewTargetMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Right)
				Cancel();
		}

		public void Cancel()
		{
			attachedTo.PreviewMouseDown -= PreviewTargetMouseDown;
			attachedTo.Cursor = null;
		}

	}


}

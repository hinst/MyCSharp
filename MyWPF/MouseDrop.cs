using System;
using System.Windows;
using System.Windows.Input;

using MyWPF;

namespace MyWPF
{

	public class MouseDrop<T> where T: DependencyObject
	{

		public MouseDrop<T> Create(Cursor cursor)
		{
			dropCursor = cursor;
			return this;
		}

		public void Drop(FrameworkElement attachTo)
		{
			attachedTo = attachTo;
			attachedTo.Cursor = DropCursor;
			attachedTo.PreviewMouseDown += PreviewTargetMouseDown;
		}

		public delegate void DropAtTargetFunction(Point point, T target);

		public DropAtTargetFunction DropAtTarget;

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
			if (e.ChangedButton == MouseButton.Left)
				DropAtPoint(e.GetPosition(AttachedTo));
		}

		protected void DropAtPoint(Point point)
		{
			var at = Mouse.DirectlyOver as FrameworkElement;
			if (at != null)
			{
				var target = at.NavigateUp<T>();
				if (target != null)
					DropAtTarget(point, target);
				Cancel();
			}
		}

		public void Cancel()
		{
			attachedTo.PreviewMouseDown -= PreviewTargetMouseDown;
			attachedTo.Cursor = null;
		}

	}


}

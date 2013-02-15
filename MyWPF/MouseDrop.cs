using System;
using System.Windows;
using System.Windows.Input;

using NLog;

using MyWPF;

namespace MyWPF
{

	public class MouseDrop<T> where T: DependencyObject
	{

		protected Logger log = LogManager.GetCurrentClassLogger();

		public delegate void DropAction(Point point, T target);

		public MouseDrop<T> Create(Cursor cursor, DropAction drop, Action cancel = null)
		{
			dropCursor = cursor;
			dropAction = drop;
			cancelAction = cancel;
			return this;
		}

		public void Drop(FrameworkElement attachTo)
		{
			attachedTo = attachTo;
			attachedTo.Cursor = DropCursor;
			attachedTo.PreviewMouseDown += PreviewTargetMouseDown;
		}

		protected DropAction dropAction;

		protected Action cancelAction;

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
				var target = at as T ?? at.NavigateUp<T>();
				if (target != null)
				{
					dropAction(point, target);
					Detach();
				}
				else
				{
					log.Debug(at);
					Cancel();
				}
			}
			else
				Cancel();
		}

		public void Cancel()
		{
			log.Debug("Cancel");
			Detach();
			if (cancelAction != null)
				cancelAction();
		}

		public void Detach()
		{
			attachedTo.PreviewMouseDown -= PreviewTargetMouseDown;
			attachedTo.Cursor = null;
		}

	}


}

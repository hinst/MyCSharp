using System;
using System.Windows;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Media;

namespace MyWPF
{

	public class ControlAdorner: Adorner
	{

		public ControlAdorner(UIElement element, Visual visual)
			: base(element)
		{
			AddVisualChild(visual);
		}

	}

}

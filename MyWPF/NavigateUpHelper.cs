#region using System
using System;
using System.Windows;
#endregion
#region using Mine
using MyCSharp;
#endregion

namespace MyWPF
{

	public static class NavigateUpHelper
	{

		public static DependencyObject NavigateUpByFunction(this FrameworkElement element, Func<DependencyObject, bool> check)
		{
			if (element == null)
				return null;
			do
			{
				var parent = element.Parent;
				if (parent == null)
					return null;
				if (check(parent))
					return parent;
				if (parent is FrameworkElement)
					element = (FrameworkElement)parent;
				else
					return null;
			}
			while (true);
		}

		public static T NavigateUp<T>(this FrameworkElement element) where T: DependencyObject
		{
			return (T) NavigateUpByFunction(element, (dependencyObject) => dependencyObject is T);
		}

		public static DependencyObject NavigateUpByType(this FrameworkElement element, Type type)
		{
			return NavigateUpByFunction(element, (dependencyObject) => dependencyObject.Is(type));
		}

	}

}

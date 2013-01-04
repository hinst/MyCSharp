using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace MyWPF
{

	public static class WaitControlHelper
	{

		static WaitControlHelper()
		{
			waitControls = new ConditionalWeakTable<UIElement, WaitControl>();
		}

		private static ConditionalWeakTable<UIElement, WaitControl> waitControls;

		public static WaitControl CreateWaitControl(UIElement element)
		{
			return new WaitControl(element);
		}

		// enable (true) & disable (false) wait state
		public static void SwitchWaitState(this UIElement element, bool state)
		{
			var waitControl = waitControls.GetValue(element, CreateWaitControl);
			waitControl.Visibility = state ? Visibility.Visible : Visibility.Hidden;
		}

	}

}

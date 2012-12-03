#region using System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
#endregion
#region using Mine
using MyCSharp;
#endregion

namespace MyWPF
{

	public class ClosePageButton: Button
	{

		protected override void OnClick()
		{
			base.OnClick();
			var tabItem = this.NavigateUp<TabItem>();
			Assert.NotNull(tabItem);
			var tabControl = tabItem.NavigateUp<TabControl>();
			Assert.NotNull(tabControl);
			tabControl.Items.Remove(tabItem);
		}

	}

}

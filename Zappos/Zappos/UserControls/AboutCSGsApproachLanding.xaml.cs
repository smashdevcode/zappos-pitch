using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Zappos.Common;

namespace Zappos.UserControls
{
	public sealed partial class AboutCSGsApproachLanding : UserControlBase
	{
		public AboutCSGsApproachLanding()
		{
			this.InitializeComponent();
		}

		private void WhyCSharpXAMLButton_Click_1(object sender, RoutedEventArgs e)
		{
			NavigateToItemDetailPage("WhyCSharpXAML");
		}

		private void ProjectManagementButton_Click_1(object sender, RoutedEventArgs e)
		{
			NavigateToItemDetailPage("ProjectManagement");
		}

		private void TestingMethodsButton_Click_1(object sender, RoutedEventArgs e)
		{
			NavigateToItemDetailPage("TestingMethods");
		}
	}
}

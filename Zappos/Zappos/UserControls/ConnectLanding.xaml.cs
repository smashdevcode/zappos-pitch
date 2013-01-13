using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
	public sealed partial class ConnectLanding : UserControlBase
	{
		public ConnectLanding()
		{
			this.InitializeComponent();
		}

		private void TwitterButton_Click_1(object sender, RoutedEventArgs e)
		{
			OpenUrl("https://twitter.com/csgpro");
		}

		private void LinkedInButton_Click_1(object sender, RoutedEventArgs e)
		{
			OpenUrl("http://www.linkedin.com/company/67626");
		}

		private void OurWebsiteButton_Click_1(object sender, RoutedEventArgs e)
		{
			OpenUrl("http://www.csgpro.com/");
		}
	}
}

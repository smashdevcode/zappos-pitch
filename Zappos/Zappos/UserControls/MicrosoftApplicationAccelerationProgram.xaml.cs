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
	public sealed partial class MicrosoftApplicationAccelerationProgram : UserControlBase
	{
		public MicrosoftApplicationAccelerationProgram()
		{
			this.InitializeComponent();
		}

		private void ViewMAAPSlideshowButton_Click_1(object sender, RoutedEventArgs e)
		{
			OpenFile(@"Assets\Windows 8 MAAP Customer.pdf");
		}
	}
}

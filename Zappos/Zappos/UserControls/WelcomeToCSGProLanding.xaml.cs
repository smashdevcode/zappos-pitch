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
using Zappos.Pages;

namespace Zappos.UserControls
{
	public sealed partial class WelcomeToCSGProLanding : UserControlBase
	{
		public WelcomeToCSGProLanding()
		{
			this.InitializeComponent();
		}

		private void MeetTheTeamButton_Click_1(object sender, RoutedEventArgs e)
		{
			NavigateToItemDetailPage("MeetTheTeam");
		}

		private void WhereWeWorkButton_Click_1(object sender, RoutedEventArgs e)
		{
			NavigateToItemDetailPage("WhereWeWork");
		}

		private void LearnOurHistoryButton_Click_1(object sender, RoutedEventArgs e)
		{
			NavigateToItemDetailPage("LearnOurHistory");
		}
	}
}

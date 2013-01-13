﻿using System;
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
	public sealed partial class ProjectDetailsLanding : UserControlBase
	{
		public ProjectDetailsLanding()
		{
			this.InitializeComponent();
		}

		private void ProjectTimelineButton_Click_1(object sender, RoutedEventArgs e)
		{
			NavigateToItemDetailPage("ProjectTimeline");
		}

		private void TechnicalRequirementsButton_Click_1(object sender, RoutedEventArgs e)
		{
			NavigateToItemDetailPage("TechnicalRequirements");
		}
	}
}

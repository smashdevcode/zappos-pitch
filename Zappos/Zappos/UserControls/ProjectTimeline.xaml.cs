using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Zappos.Common;

namespace Zappos.UserControls
{
	public sealed partial class ProjectTimeline : UserControlBase
	{
		private SolidColorBrush _circleDefaultColor = new SolidColorBrush(Color.FromArgb(0xFF, 0, 0, 0));
		private SolidColorBrush _circleHighlightColor = new SolidColorBrush(Color.FromArgb(0xFF, 0x74, 0x99, 0xC6));

		public ProjectTimeline()
		{
			this.InitializeComponent();
		}

		private void Week1Circle_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			ToggleWeek(Week1Grid, Week1Circle, ShowWeek1Grid, HideWeek1Grid);
		}

		private void Week2Circle_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			ToggleWeek(Week2Grid, Week2Circle, ShowWeek2Grid, HideWeek2Grid);
		}

		private void Week3Circle_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			ToggleWeek(Week3Grid, Week3Circle, ShowWeek3Grid, HideWeek3Grid);
		}

		private void Week4Circle_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			ToggleWeek(Week4Grid, Week4Circle, ShowWeek4Grid, HideWeek4Grid);
		}

		private void Week6Circle_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			ToggleWeek(Week6Grid, Week6Circle, ShowWeek6Grid, HideWeek6Grid);
		}

		private void Week7Circle_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			ToggleWeek(Week7Grid, Week7Circle, ShowWeek7Grid, HideWeek7Grid);
		}

		private void Week8Circle_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			ToggleWeek(Week8Grid, Week8Circle, ShowWeek8Grid, HideWeek8Grid);
		}

		private void ResetCircleColors()
		{
			Week1Circle.Fill = _circleDefaultColor;
			Week2Circle.Fill = _circleDefaultColor;
			Week3Circle.Fill = _circleDefaultColor;
			Week4Circle.Fill = _circleDefaultColor;
			Week6Circle.Fill = _circleDefaultColor;
			Week7Circle.Fill = _circleDefaultColor;
			Week8Circle.Fill = _circleDefaultColor;
		}

		private void HideAllGrids()
		{
			Week1Grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			Week2Grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			Week3Grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			Week4Grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			Week6Grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			Week7Grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			Week8Grid.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
		}

		private void ToggleWeek(Grid grid, Ellipse circle, Storyboard show, Storyboard hide)
		{
			if (grid.Visibility == Windows.UI.Xaml.Visibility.Collapsed)
			{
				HideAllGrids();
				ResetCircleColors();
				grid.Visibility = Windows.UI.Xaml.Visibility.Visible;
				circle.Fill = _circleHighlightColor;
				show.Begin();
			}
			else
			{
				HideAllGrids();
				ResetCircleColors();
				circle.Fill = _circleDefaultColor;
				hide.Begin();
			}
		}
	}
}

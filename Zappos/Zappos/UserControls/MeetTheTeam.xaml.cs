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
	public sealed partial class MeetTheTeam : UserControlBase
	{
		private const double _fadeOutOpacity = 0.4;

		public MeetTheTeam()
		{
			this.InitializeComponent();
		}

		private void RonPhoto_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			RonQuote.Visibility = Windows.UI.Xaml.Visibility.Visible;
			KevinQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			JamesQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			RonPhoto.Opacity = 1;
			KevinPhoto.Opacity = _fadeOutOpacity;
			JamesPhoto.Opacity = _fadeOutOpacity;
			RonJobTitle.Opacity = 1;
			KevinJobTitle.Opacity = _fadeOutOpacity;
			JamesJobTitle.Opacity = _fadeOutOpacity;
			ShowRonQuote.Begin();
		}

		private void KevinPhoto_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			RonQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			KevinQuote.Visibility = Windows.UI.Xaml.Visibility.Visible;
			JamesQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			RonPhoto.Opacity = _fadeOutOpacity;
			KevinPhoto.Opacity = 1;
			JamesPhoto.Opacity = _fadeOutOpacity;
			RonJobTitle.Opacity = _fadeOutOpacity;
			KevinJobTitle.Opacity = 1;
			JamesJobTitle.Opacity = _fadeOutOpacity;
			ShowKevinQuote.Begin();
		}

		private void JamesPhoto_Tapped_1(object sender, TappedRoutedEventArgs e)
		{
			RonQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			KevinQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			JamesQuote.Visibility = Windows.UI.Xaml.Visibility.Visible;
			RonPhoto.Opacity = _fadeOutOpacity;
			KevinPhoto.Opacity = _fadeOutOpacity;
			JamesPhoto.Opacity = 1;
			RonJobTitle.Opacity = _fadeOutOpacity;
			KevinJobTitle.Opacity = _fadeOutOpacity;
			JamesJobTitle.Opacity = 1;
			ShowJamesQuote.Begin();
		}

		private void CloseRonQuoteButton_Click_1(object sender, RoutedEventArgs e)
		{
			HideRonQuote.Completed += (completedSender, completeEventArgs) =>
			{
				RonQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
				ShowAllPhotosAndJobTitles();
			};
			HideRonQuote.Begin();
		}

		private void CloseKevinQuoteButton_Click_1(object sender, RoutedEventArgs e)
		{
			HideKevinQuote.Completed += (completedSender, completeEventArgs) =>
			{
				KevinQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
				ShowAllPhotosAndJobTitles();
			};
			HideKevinQuote.Begin();
		}

		private void CloseJamesQuoteButton_Click_1(object sender, RoutedEventArgs e)
		{
			HideJamesQuote.Completed += (completedSender, completeEventArgs) =>
			{
				JamesQuote.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
				ShowAllPhotosAndJobTitles();
			};
			HideJamesQuote.Begin();
		}

		private void ShowAllPhotosAndJobTitles()
		{
			RonPhoto.Opacity = 1;
			KevinPhoto.Opacity = 1;
			JamesPhoto.Opacity = 1;
			RonJobTitle.Opacity = 1;
			KevinJobTitle.Opacity = 1;
			JamesJobTitle.Opacity = 1;
		}
	}
}

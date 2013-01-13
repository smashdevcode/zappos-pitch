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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Zappos.Common;
using Zappos.Data;

namespace Zappos.UserControls
{
	public sealed partial class BreadcrumbMenu : UserControlBase
	{
		#region Private Fields
		private Style _buttonStyle = null;
		private BitmapImage _breadcrumbArrow = null;
		#endregion

		public BreadcrumbMenu()
		{
			this.InitializeComponent();
		}

		#region CurrentItem
		public PitchItem CurrentItem
		{
			get { return (PitchItem)GetValue(CurrentItemProperty); }
			set { SetValue(CurrentItemProperty, value); }
		}

		public static readonly DependencyProperty CurrentItemProperty =
			DependencyProperty.Register("CurrentItem", typeof(PitchItem), typeof(BreadcrumbMenu), 
			new PropertyMetadata(null, new PropertyChangedCallback(OnCurrentItemChanged)));

		private static void OnCurrentItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var control = d as BreadcrumbMenu;
			if (control != null)
			{
				control.BuildBreadcrumbMenu((PitchItem)e.NewValue);
			}
		}
		#endregion CurrentItem

		#region Methods
		private void BuildBreadcrumbMenu(PitchItem currentItem)
		{
			if (currentItem != null)
			{
				// if null, get the button style and breadcrumb arrow image
				if (_buttonStyle == null)
				{
					switch (currentItem.ColorScheme)
					{
						case Enums.PageColorScheme.Dark:
							_buttonStyle = (Style)App.Current.Resources["BreadcrumbMenuStyleDark"];
							break;
						case Enums.PageColorScheme.Light:
							_buttonStyle = (Style)App.Current.Resources["BreadcrumbMenuStyleLight"];
							break;
						default:
							throw new Exception("Unexpected PageColorScheme enum value: " + currentItem.ColorScheme.ToString());
					}
				}
				if (_breadcrumbArrow == null)
				{
					switch (currentItem.ColorScheme)
					{
						case Enums.PageColorScheme.Dark:
							_breadcrumbArrow = (BitmapImage)App.Current.Resources["BreadcrumbMenuArrowSmallDark"];
							break;
						case Enums.PageColorScheme.Light:
							_breadcrumbArrow = (BitmapImage)App.Current.Resources["BreadcrumbMenuArrowSmallLight"];
							break;
						default:
							throw new Exception("Unexpected PageColorScheme enum value: " + currentItem.ColorScheme.ToString());
					}
				}

				var pitchItem = currentItem;
				var firstItem = true;
				while (pitchItem != null)
				{
					var button = GetButton(pitchItem.PageTitle);
					// if this is the first item in the list (from right to left)
					// then hide the hit test
					// otherwise wire up a click handler
					if (firstItem)
					{
						button.IsHitTestVisible = false;
					}
					else
					{
						var pitchItemUniqueId = pitchItem.UniqueId;
						button.Click += (clickSender, clickEventArgs) =>
						{
							NavigateToItemDetailPage(pitchItemUniqueId);
						};
					}
					MenuItems.Children.Insert(0, button);

					// add separator arrow
					var arrowImage = new Image();
					arrowImage.Source = _breadcrumbArrow;
					arrowImage.Stretch = Stretch.None;
					MenuItems.Children.Insert(0, arrowImage);

					// if we have a parent pitch item, then update the pitch item reference
					// otherwise we should have a reference to the top level group
					// which we can use to the build the left most button
					if (pitchItem.ParentPitchItem != null)
					{
						// set the pitch item to the parent pitch item
						pitchItem = pitchItem.ParentPitchItem;
					}
					else
					{
						// make sure that the last pitch has a group reference
						if (pitchItem.Group == null)
							throw new Exception("Any pitch item that does not have a parent pitch item, should have a reference to a group.");

						// setup the group button
						var groupButton = GetButton("Home");
						groupButton.Click += (clickSender, clickEventArgs) =>
						{
							NavigateToHomePage();
						};
						MenuItems.Children.Insert(0, groupButton);

						// set the pitch item to null (to break out of the loop)
						pitchItem = null;
					}

					// update the first item flag
					firstItem = false;
				}
			}
			else
			{
				MenuItems.Children.Clear();
			}
		}
		private Button GetButton(string content)
		{
			var button = new Button();
			button.Content = content;
			button.Style = _buttonStyle;
			return button;
		}
		#endregion
	}
}

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
using Zappos.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zappos.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ItemDetail : Zappos.Common.LayoutAwarePage
	{
		private string _selectedItem = null;

		public ItemDetail()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Populates the page with content passed during navigation.  Any saved state is also
		/// provided when recreating a page from a prior session.
		/// </summary>
		/// <param name="navigationParameter">The parameter value passed to
		/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
		/// </param>
		/// <param name="pageState">A dictionary of state preserved by this page during an earlier
		/// session.  This will be null the first time a page is visited.</param>
		protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
		{
			// Allow saved page state to override the initial item to display
			if (pageState != null && pageState.ContainsKey("SelectedItem"))
			{
				navigationParameter = pageState["SelectedItem"];
			}

			// get the item
			var item = DataSource.GetItem((string)navigationParameter);

			// store the item id (used to save state when necessary)
			_selectedItem = item.UniqueId;

			// determine the back button style
			switch (item.ColorScheme)
			{
				case Enums.PageColorScheme.Dark:
					backButton.Style = (Style)App.Current.Resources["BackButtonStyleDark"];
					break;
				case Enums.PageColorScheme.Light:
					backButton.Style = (Style)App.Current.Resources["BackButtonStyleLight"];
					break;
				default:
					throw new Exception("Unexpected PageColorScheme enum value: " + item.ColorScheme.ToString());
			}

			// set the breadcrumb current item
			BreadcrumbMenu.CurrentItem = item;
	
			// attempt to load the associated user control
			var itemType = Type.GetType(string.Format("Zappos.UserControls.{0}", item.UniqueId));
			if (itemType != null)
			{
				var itemInstance = (UserControlBase)Activator.CreateInstance(itemType);
				itemInstance.Name = "ContentUserControl";
				itemInstance.Navigate += (navigateSender, navigateEventArgs) =>
				{
					this.Frame.Navigate(navigateEventArgs.PageType, navigateEventArgs.Parameter);
				};
				itemInstance.Name = "ContentUserControl";
				Grid.SetRowSpan(itemInstance, 3);
				MainGrid.Children.Insert(0, itemInstance);
			}
		}

		/// <summary>
		/// Preserves state associated with this page in case the application is suspended or the
		/// page is discarded from the navigation cache.  Values must conform to the serialization
		/// requirements of <see cref="SuspensionManager.SessionState"/>.
		/// </summary>
		/// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
		protected override void SaveState(Dictionary<String, Object> pageState)
		{
			pageState["SelectedItem"] = _selectedItem;
		}

		/// <summary>
		/// Handles the breadcrumb menu Navigate event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BreadcrumbMenu_Navigate_1(object sender, UserControlBase.NavigateEventArgs e)
		{
			this.Frame.Navigate(e.PageType, e.Parameter);
		}
	}
}

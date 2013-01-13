using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Zappos.Pages;

namespace Zappos.Common
{
	public class UserControlBase : UserControl
	{
		#region Navigate Event
		/// <summary>
		/// Event args for the Navigate event.
		/// </summary>
		public class NavigateEventArgs
		{
			public NavigateEventArgs(Type pageType, string parameter)
			{
				this.PageType = pageType;
				this.Parameter = parameter;
			}

			public Type PageType { get; set; }
			public string Parameter { get; set; }
		}

		/// <summary>
		/// Multicast event for page navigations.
		/// </summary>
		public event EventHandler<NavigateEventArgs> Navigate;

		/// <summary>
		/// Notifies listeners that a page navigation has been requested.
		/// </summary>
		protected void OnNavigate(Type pageType, string parameter)
		{
			var eventHandler = this.Navigate;
			if (eventHandler != null)
			{
				eventHandler(this, new NavigateEventArgs(pageType, parameter));
			}
		}
		#endregion

		#region Methods
		public void NavigateToHomePage()
		{
			OnNavigate(typeof(Home), null);
		}
		public void NavigateToItemDetailPage(string itemId)
		{
			OnNavigate(typeof(ItemDetail), itemId);
		}
		public async void OpenUrl(string url)
		{
			var uri = new Uri(url);
			var options = new LauncherOptions();
			options.TreatAsUntrusted = false;
			var success = await Launcher.LaunchUriAsync(uri, options);
		}
		public async void OpenFile(string fileName)
		{
			var uri = new Uri(string.Format("ms-appx:///{0}", fileName));
			var file = await StorageFile.GetFileFromApplicationUriAsync(uri);

			if (file != null)
			{
				var options = new Windows.System.LauncherOptions();
				//options.DisplayApplicationPicker = true;
				bool success = await Launcher.LaunchFileAsync(file, options);
				//if (success)
				//{
				//	// File launched
				//}
				//else
				//{
				//	// File launch failed
				//}
			}
		}
		#endregion
	}
}

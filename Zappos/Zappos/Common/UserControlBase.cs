using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		#endregion
	}
}

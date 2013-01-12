using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Zappos.Data
{
	public enum PitchItemLayout
	{
		Standard,
		Tall,
		Wide,
		WideWithArrow,
		ExtraWide,
		TextOnly
	}

	public sealed class DataSource
	{
		private static DataSource _dataSource = new DataSource();

		private ObservableCollection<PitchItemGroup> _allGroups = new ObservableCollection<PitchItemGroup>();
		public ObservableCollection<PitchItemGroup> AllGroups
		{
			get { return this._allGroups; }
		}

		private ObservableCollection<PitchItem> _allItems = new ObservableCollection<PitchItem>();
		public ObservableCollection<PitchItem> AllItems
		{
			get { return this._allItems; }
		}

		public static ObservableCollection<PitchItemGroup> GetGroups()
		{
			return _dataSource.AllGroups;
		}
		public static PitchItemGroup GetGroup(string uniqueId)
		{
			return _dataSource.AllGroups.Where((group) => group.UniqueId == uniqueId).FirstOrDefault();
		}
		public static PitchItem GetItem(string uniqueId)
		{
			return _dataSource.AllItems.Where((item) => item.UniqueId == uniqueId).FirstOrDefault();
		}

		public DataSource()
		{
			//Windows Store Application
			//	Welcome to CSG Pro
			//		Learn Our History
			//		Where We Work
			//		Meet Our Management

			var group1 = new PitchItemGroup(
				"WindowsStoreApplication",
				"Windows Store Application");

			var welcomeToCSGPro = new PitchItem(
				"WelcomeToCSGPro",
				"Welcome to CSG Pro",
				"Let us put a smile on your face. Learn more about CSG Pro.",
				null,
				null,
				"Assets/PhotoChick4.jpg",
				null,
				PitchItemLayout.ExtraWide,
				group1);
			group1.Items.Add(welcomeToCSGPro);
			this.AllItems.Add(welcomeToCSGPro);

			var learnOurHistory = new PitchItem(
				"LearnOurHistory",
				"Learn Our History",
				parentPitchItem: welcomeToCSGPro);
			var whereWeWork = new PitchItem(
				"WhereWeWork",
				"Where We Work",
				parentPitchItem: welcomeToCSGPro);
			var meetOurManagement = new PitchItem(
				"MeetOurManagement",
				"Meet Our Management",
				parentPitchItem: welcomeToCSGPro);
			this.AllItems.Add(learnOurHistory);
			this.AllItems.Add(whereWeWork);
			this.AllItems.Add(meetOurManagement);

			var welcome = new PitchItem(
				"Welcome",
				"Welcome",
				"Welcome! We're glad you're here.",
				null,
				"You may have already noticed, but we built you an app. We really like the idea of putting Zappos.com on the Windows App Store and wanted to show you that we're pretty excited about it.\n\nSo welcome. This application will guide you through the details of our overall approach and hopefully answer any questions you may have. Enjoy!",
				null,
				null,
				PitchItemLayout.TextOnly,
				group1);
			group1.Items.Add(welcome);
			this.AllItems.Add(welcome);

			this.AllGroups.Add(group1);

			//More Information
			//	About Our Approach
			//		Project Management
			//		Testing
			//		Why C#/XAML?
			//	Connect
			//	Project Details
			//		Requirements
			//		Timeline
			//	Microsoft Application Acceleration Program (MAAP)

			var group2 = new PitchItemGroup(
				"MoreInformation",
				"More Information");

			var aboutOurApproach = new PitchItem(
				"AboutOurApproach",
				"About Our Approach",
				"Learn about our approach. And the gear that we use.",
				null,
				null,
				"Assets/PhotoGear.jpg",
				null,
				PitchItemLayout.Standard,
				group2);
			group2.Items.Add(aboutOurApproach);
			this.AllItems.Add(aboutOurApproach);

			var projectManagement = new PitchItem(
				"ProjectManagement",
				"Project Management",
				parentPitchItem: aboutOurApproach);
			var testing = new PitchItem(
				"Testing",
				"Testing",
				parentPitchItem: aboutOurApproach);
			var whyCSharpXAML = new PitchItem(
				"WhyCSharpXAML",
				"Why C#/XAML?",
				parentPitchItem: aboutOurApproach);
			this.AllItems.Add(projectManagement);
			this.AllItems.Add(testing);
			this.AllItems.Add(whyCSharpXAML);

			var projectDetails = new PitchItem(
				"ProjectDetails",
				"Project Details",
				"Running resolutions. Check out the project details.",
				null,
				null,
				"Assets/PhotoRunning.jpg",
				null,
				PitchItemLayout.Standard,
				group2);
			group2.Items.Add(projectDetails);
			this.AllItems.Add(projectDetails);

			var requirements = new PitchItem(
				"Requirements",
				"Requirements",
				parentPitchItem: projectDetails);
			var timeline = new PitchItem(
				"Timeline",
				"Timeline",
				parentPitchItem: projectDetails);
			this.AllItems.Add(requirements);
			this.AllItems.Add(timeline);

			var connect = new PitchItem(
				"Connect",
				"Connect",
				"We want to get to know you better. Connect with us!",
				null,
				null,
				"Assets/PhotoDude.jpg",
				null,
				PitchItemLayout.WideWithArrow,
				group2);
			group2.Items.Add(connect);
			this.AllItems.Add(connect);

			var maap = new PitchItem(
				"MAAP",
				"Microsoft Application Acceleration Program (MAAP)",
				"Learn about the Windows 8 Microsoft Application Acceleration Program (MAAP).",
				null,
				null,
				"Assets/PhotoChick2.jpg",
				null,
				PitchItemLayout.WideWithArrow,
				group2);
			group2.Items.Add(maap);
			this.AllItems.Add(maap);

			this.AllGroups.Add(group2);
		}
	}

	[Windows.Foundation.Metadata.WebHostHidden]
	public class PitchItemCommon : Zappos.Common.BindableBase
	{
		private static Uri _baseUri = new Uri("ms-appx:///");

		public PitchItemCommon(string uniqueId, string title, string subtitle, string description, string imagePath)
		{
			this._uniqueId = uniqueId;
			this._title = title;
			this._subtitle = subtitle;
			this._description = description;
			this._imagePath = imagePath;
		}

		private string _uniqueId = string.Empty;
		public string UniqueId
		{
			get { return this._uniqueId; }
			set { this.SetProperty(ref this._uniqueId, value); }
		}

		private string _title = string.Empty;
		public string Title
		{
			get { return this._title; }
			set { this.SetProperty(ref this._title, value); }
		}

		private string _subtitle = string.Empty;
		public string Subtitle
		{
			get { return this._subtitle; }
			set { this.SetProperty(ref this._subtitle, value); }
		}

		private string _description = string.Empty;
		public string Description
		{
			get { return this._description; }
			set { this.SetProperty(ref this._description, value); }
		}

		private ImageSource _image = null;
		private String _imagePath = null;
		public ImageSource Image
		{
			get
			{
				if (this._image == null && this._imagePath != null)
				{
					this._image = new BitmapImage(new Uri(PitchItemCommon._baseUri, this._imagePath));
				}
				return this._image;
			}

			set
			{
				this._imagePath = null;
				this.SetProperty(ref this._image, value);
			}
		}

		public void SetImage(String path)
		{
			this._image = null;
			this._imagePath = path;
			this.OnPropertyChanged("Image");
		}

		public override string ToString()
		{
			return this.Title;
		}
	}

	public class PitchItem : PitchItemCommon
	{
		public PitchItem(string uniqueId, string pageTitle, string title = null, string subtitle = null, string description = null, string imagePath = null,
			string content = null, PitchItemLayout layout = PitchItemLayout.Standard, PitchItemGroup group = null, PitchItem parentPitchItem = null)
			: base(uniqueId, title, subtitle, description, imagePath)
		{
			this._pageTitle = pageTitle;
			this._content = content;
			this._layout = layout;
			this._group = group;
			this._parentPitchItem = parentPitchItem;
		}

		private string _pageTitle = string.Empty;
		public string PageTitle
		{
			get { return this._pageTitle; }
			set { this.SetProperty(ref this._pageTitle, value); }
		}

		private string _content = string.Empty;
		public string Content
		{
			get { return this._content; }
			set { this.SetProperty(ref this._content, value); }
		}

		private PitchItemLayout _layout = PitchItemLayout.Standard;
		public PitchItemLayout Layout
		{
			get { return this._layout; }
			set { this.SetProperty(ref this._layout, value); }
		}

		private PitchItemGroup _group;
		public PitchItemGroup Group
		{
			get { return this._group; }
			set { this.SetProperty(ref this._group, value); }
		}

		private PitchItem _parentPitchItem;
		public PitchItem ParentPitchItem
		{
			get { return this._parentPitchItem; }
			set { this.SetProperty(ref this._parentPitchItem, value); }
		}

		public override string ToString()
		{
			return this.Title;
		}
	}

	public class PitchItemGroup : PitchItemCommon
	{
		public PitchItemGroup(string uniqueId, string title, string subtitle = null, string description = null, string imagePath = null)
			: base(uniqueId, title, subtitle, description, imagePath)
		{
		}

		private ObservableCollection<PitchItem> _items = new ObservableCollection<PitchItem>();
		public ObservableCollection<PitchItem> Items
		{
			get { return this._items; }
		}
	}
}

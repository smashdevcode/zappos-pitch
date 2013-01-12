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
			return _dataSource.AllGroups.SelectMany(group => group.Items).Where((item) => item.UniqueId == uniqueId).FirstOrDefault();
		}

		public DataSource()
		{
			// JCTODO load data from XML???

			var itemContent = string.Format("Item Content: {0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}",
				"Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat");

			var group1 = new PitchItemGroup(
					"WindowsStoreApplication",
					"Windows Store Application",
					null,
					null,
					"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
			group1.Items.Add(new PitchItem(
				"Item1",
				"Let us put a smile on your face.",
				null,
				"Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
				"Assets/PhotoChick4.jpg",
				itemContent,
				PitchItemLayout.ExtraWide,
				group1));
			group1.Items.Add(new PitchItem(
				"Item2",
				"Why Use XAML/C#?",
				"From all of the options available to develop Windows Store applications, why use XAML and C#?",
				"Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
				null,
				itemContent,
				PitchItemLayout.TextOnly,
				group1));
			group1.Items.Add(new PitchItem(
				"Item3",
				"Learn about Microsoft's MAAP program.",
				"Take full advantage of Microsoft's desire to build Windows Store applications for Windows 8; let them fund some of the development effort.",
				"Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
				null,
				itemContent,
				PitchItemLayout.TextOnly,
				group1));
			this.AllGroups.Add(group1);

			var group2 = new PitchItemGroup(
					"MoreInformation",
					"More Information",
					null,
					null,
					"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
			group2.Items.Add(new PitchItem(
				"Item4",
				"Learn more about CSG Pro.",
				null,
				"Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
				"Assets/PhotoChick3.jpg",
				itemContent,
				PitchItemLayout.Standard,
				group2));
			group2.Items.Add(new PitchItem(
				"Item5",
				"Find the shopping app that fits your style. Zappos on iOS, Android and Windows 8.",
				null,
				"Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
				"Assets/PhotoDude.jpg",
				itemContent,
				PitchItemLayout.WideWithArrow,
				group2));
			group2.Items.Add(new PitchItem(
				"Item6",
				"Check out the timeline.",
				null,
				"Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
				"Assets/PhotoChick1.jpg",
				itemContent,
				PitchItemLayout.Standard,
				group2));
			group2.Items.Add(new PitchItem(
				"Item7",
				"Find the shopping app that fits your style. Zappos on iOS, Android and Windows 8.",
				null,
				"Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
				"Assets/PhotoChick2.jpg",
				itemContent,
				PitchItemLayout.WideWithArrow,
				group2));
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
		public PitchItem(string uniqueId, string title, string subtitle, string description, string imagePath, 
			string content, PitchItemLayout layout, PitchItemGroup group)
			: base(uniqueId, title, subtitle, description, imagePath)
		{
			this._content = content;
			this._layout = layout;
			this._group = group;
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

		public override string ToString()
		{
			return this.Title;
		}
	}

	public class PitchItemGroup : PitchItemCommon
	{
		public PitchItemGroup(string uniqueId, string title, string subtitle, string description, string imagePath)
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

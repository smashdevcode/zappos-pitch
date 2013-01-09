using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Zappos.Data;

namespace Zappos.Common
{
	public class PitchItemDataTemplateSelector : DataTemplateSelector
	{
		public DataTemplate ItemTemplateStandard { get; set; }
		public DataTemplate ItemTemplateTall { get; set; }
		public DataTemplate ItemTemplateWide { get; set; }

		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
		{
			var pitchItem = item as PitchItem;
			var uiElement = container as UIElement;
			if (pitchItem != null && uiElement != null)
			{
				switch (pitchItem.Layout)
				{
					case PitchItemLayout.Standard:
						SetColumnRowSpan(uiElement, 1, 1);
						return ItemTemplateStandard;
					case PitchItemLayout.Tall:
						SetColumnRowSpan(uiElement, 1, 2);
						return ItemTemplateTall;
					case PitchItemLayout.Wide:
						SetColumnRowSpan(uiElement, 2, 1);
						return ItemTemplateWide;
					default:
						throw new Exception("Unexpected PitchItemLayout enum value: " + pitchItem.Layout.ToString());
				}
			}

			//SetColumnRowSpan(uiElement, 1, 1);
			return ItemTemplateStandard;

			// JCTODO remove???
			//return null;
		}

		private void SetColumnRowSpan(UIElement uiElement, int columnSpan, int rowSpan)
		{
			VariableSizedWrapGrid.SetColumnSpan(uiElement, columnSpan);
			VariableSizedWrapGrid.SetRowSpan(uiElement, rowSpan);
		}
	}

	// JCTODO remove
	//public class PitchItemTemplateSelector : TemplateSelector
	//{
	//	public DataTemplate ItemTemplateStandard { get; set; }
	//	public DataTemplate ItemTemplateTall { get; set; }
	//	public DataTemplate ItemTemplateWide { get; set; }

	//	public override DataTemplate SelectTemplate(object item, DependencyObject container)
	//	{
	//		var pitchItem = item as PitchItem;
	//		var uiElement = container as UIElement;
	//		if (pitchItem != null && uiElement != null)
	//		{
	//			switch (pitchItem.Layout)
	//			{
	//				case PitchItemLayout.Standard:
	//					SetColumnRowSpan(uiElement, 1, 1);
	//					return ItemTemplateStandard;
	//				case PitchItemLayout.Tall:
	//					SetColumnRowSpan(uiElement, 1, 2);
	//					return ItemTemplateTall;
	//				case PitchItemLayout.Wide:
	//					SetColumnRowSpan(uiElement, 2, 1);
	//					return ItemTemplateWide;
	//				default:
	//					throw new Exception("Unexpected PitchItemLayout enum value: " + pitchItem.Layout.ToString());
	//			}
	//		}

	//		return null;
	//	}

	//	private void SetColumnRowSpan(UIElement uiElement, int columnSpan, int rowSpan)
	//	{
	//		VariableSizedWrapGrid.SetColumnSpan(uiElement, columnSpan);
	//		VariableSizedWrapGrid.SetRowSpan(uiElement, rowSpan);
	//	}
	//}
}

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
		public DataTemplate ItemTemplateWideWithArrow { get; set; }
		public DataTemplate ItemTemplateExtraWide { get; set; }
		public DataTemplate ItemTemplateStandardTextOnly { get; set; }
		public DataTemplate ItemTemplateExtraWideTextOnly { get; set; }

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
					case PitchItemLayout.WideWithArrow:
						SetColumnRowSpan(uiElement, 2, 1);
						return ItemTemplateWideWithArrow;
					case PitchItemLayout.ExtraWide:
						SetColumnRowSpan(uiElement, 3, 1);
						return ItemTemplateExtraWide;
					case PitchItemLayout.StandardTextOnly:
						uiElement.IsHitTestVisible = false;
						SetColumnRowSpan(uiElement, 1, 1);
						return ItemTemplateStandardTextOnly;
					case PitchItemLayout.ExtraWideTextOnly:
						uiElement.IsHitTestVisible = false;
						SetColumnRowSpan(uiElement, 3, 1);
						return ItemTemplateExtraWideTextOnly;
					default:
						throw new Exception("Unexpected PitchItemLayout enum value: " + pitchItem.Layout.ToString());
				}
			}
			return ItemTemplateStandard;
		}

		private void SetColumnRowSpan(UIElement uiElement, int columnSpan, int rowSpan)
		{
			VariableSizedWrapGrid.SetColumnSpan(uiElement, columnSpan);
			VariableSizedWrapGrid.SetRowSpan(uiElement, rowSpan);
		}
	}
}

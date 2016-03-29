using Storm.StardewValley.Accessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class OptionsPage : ClickableMenu
    {
        public OptionsPage(StaticContext parent, OptionsPageAccessor accessor) :
            base(parent, accessor)
        {

        }

        public OptionsPage()
        {
        }

        public string DescriptionText
        {
            get { return Cast<OptionsPageAccessor>()._GetDescriptionText(); }
            set { Cast<OptionsPageAccessor>()._SetDescriptionText(value); }
        }

        public string HoverText
        {
            get { return Cast<OptionsPageAccessor>()._GetHoverText(); }
            set { Cast<OptionsPageAccessor>()._SetHoverText(value); }
        }

        public IList OptionSlots
        {
            get { return Cast<OptionsPageAccessor>()._GetOptionSlots(); }
            set { Cast<OptionsPageAccessor>()._SetOptionSlots(value); }
        }

        public int CurrentItemIndex
        {
            get { return Cast<OptionsPageAccessor>()._GetCurrentItemIndex(); }
            set { Cast<OptionsPageAccessor>()._SetCurrentItemIndex(value); }
        }

        public IList Options
        {
            get { return Cast<OptionsPageAccessor>()._GetOptions(); }
            set { Cast<OptionsPageAccessor>()._SetOptions(value); }
        }
    }
}

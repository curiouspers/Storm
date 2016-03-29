using Storm.StardewValley.Accessor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class OptionsElement : StaticContextWrapper
    {
        public OptionsElement(StaticContext parent, OptionsElementAccessor accessor)
        {
            Underlying = accessor;
        }
        public OptionsElement() { }

        public int WhichOption
        {
            get { return Cast<OptionsElementAccessor>()._GetWhichOption(); }
            set { Cast<OptionsElementAccessor>()._SetWhichOption(value); }
        }
    }

    public class OptionsDropDown : OptionsElement
    {

        public IList DropDownOptions
        {
            get { return Cast<OptionsDropDownAccessor>()._GetDropDownOptions(); }
            set { Cast<OptionsDropDownAccessor>()._SetDropDownOptions(value); }
        }

        public OptionsDropDown(StaticContext parent, OptionsDropDownAccessor accessor) : base(parent, accessor)
        {
            Underlying = accessor;
        }
        public OptionsDropDown() { }
    }
}

using Storm.Manipulation;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class ChangeDropDownOptionsEvent : DetourEvent
    {
        public ChangeDropDownOptionsEvent(Options accessor, int which, int selection, List<string> options)
        {
            Accessor = accessor;
            Which = which;
            Selection = selection;
            Options = options;
        }

        public Options Accessor { get; }
        public int Which { get; }
        public int Selection { get; }
        public List<string> Options { get; }
    }
    public class SetDropDownToProperValueEvent : DetourEvent
    {
        public SetDropDownToProperValueEvent(Options accessor, OptionsDropDown dropDown)
        {
            Accessor = accessor;
            DropDown = dropDown;
        }

        public Options Accessor { get; }
        public OptionsDropDown DropDown { get; }
    }
}

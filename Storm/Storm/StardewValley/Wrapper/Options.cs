using Storm.StardewValley.Accessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Wrapper
{
    public class Options : StaticContextWrapper
    {
        public Options(StaticContext parent, OptionsAccessor accessor)
        {
            Underlying = accessor;
        }

        public bool AutoRun
        {
            get { return Cast<OptionsAccessor>()._GetAutoRun(); }
            set { Cast<OptionsAccessor>()._SetAutoRun(value); }
        }
        public bool DialogueTyping
        {
            get { return Cast<OptionsAccessor>()._GetDialogueTyping(); }
            set { Cast<OptionsAccessor>()._SetDialogueTyping(value); }
        }
        public bool Fullscreen
        {
            get { return Cast<OptionsAccessor>()._GetFullscreen(); }
            set { Cast<OptionsAccessor>()._SetFullscreen(value); }
        }
        public bool WindowedBorderlessFullscreen
        {
            get { return Cast<OptionsAccessor>()._GetWindowedBorderlessFullscreen(); }
            set { Cast<OptionsAccessor>()._SetWindowedBorderlessFullscreen(value); }
        }
        public bool ShowPortraits
        {
            get { return Cast<OptionsAccessor>()._GetShowPortraits(); }
            set { Cast<OptionsAccessor>()._SetShowPortraits(value); }
        }
    }
}

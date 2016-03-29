using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Accessor
{
    public interface OptionsElementAccessor
    {
        int _GetWhichOption();
        void _SetWhichOption(int val);
    }
    public interface OptionsDropDownAccessor : OptionsElementAccessor
    {
        IList _GetDropDownOptions();
        void _SetDropDownOptions(IList val);
    }
}

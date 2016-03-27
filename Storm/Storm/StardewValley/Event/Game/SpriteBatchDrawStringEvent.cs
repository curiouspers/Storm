using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.StardewValley.Event
{
    public class SpriteBatchDrawStringEvent : StaticContextEvent
    {
        public SpriteBatchDrawStringEvent(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
    public class SpriteFontMeasureStringEvent : StaticContextEvent
    {
        public SpriteFontMeasureStringEvent(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}

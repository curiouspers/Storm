﻿using Storm.ExternalEvent;
using Storm.StardewValley;
using Storm.StardewValley.Event;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freeze_Time_Mod
{
    [Mod(Author = "Demmonic", Name = "Freeze Time Indoors", Version = 0.1D)]
    public class FreezeTimeMod : DiskResource
    {
        [Subscribe]
        public void PostRenderCallback(PostRenderEvent @event)
        {
            var batch = @event.Root.SpriteBatch;
            var font = @event.Root.SmoothFont;
            batch.DrawString(font, "Freeze Time Indoors - Example " + PathOnDisk, new Vector2(16, 16), Color.Red);
        }

        [Subscribe]
        public void PerformClockUpdateCallback(PerformClockUpdateEvent @event)
        {
            var loc = @event.Root.CurrentLocation;
            @event.ReturnEarly = (loc != null && !loc.IsOutdoors);
        }
    }
}
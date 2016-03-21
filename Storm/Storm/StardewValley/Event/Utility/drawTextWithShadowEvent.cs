/*
    Copyright 2016 @curiouspers

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Storm.Collections;
using Storm.StardewValley.Accessor;
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event
{
    public class DrawTextWithShadowEvent : StaticContextEvent
    {
        public DrawTextWithShadowEvent(SpriteBatch b, string text, SpriteFont font, Vector2 position, Color color, float scale = 1f, float layerDepth = -1f, int horizontalShadowOffset = -1, int verticalShadowOffset = -1, float shadowIntensity = 1f, int numShadows = 3)
        {
            B = b;
            Text = text;
            Font = font;
            Position = position;
            Color = color;
            Scale = scale;
            LayerDepth = layerDepth;
            HorizontalShadowOffset = horizontalShadowOffset;
            VerticalShadowOffset = verticalShadowOffset;
            ShadowIntensity = shadowIntensity;
            NumShadows = numShadows;
        }

        public SpriteBatch B { get; set; }
        public string Text { get; set; }
        public SpriteFont Font { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Scale { get; set; }
        public float LayerDepth { get; set; }
        public int HorizontalShadowOffset { get; set; }
        public int VerticalShadowOffset { get; set; }
        public float ShadowIntensity { get; set; }
        public int NumShadows { get; set; }
    }
}
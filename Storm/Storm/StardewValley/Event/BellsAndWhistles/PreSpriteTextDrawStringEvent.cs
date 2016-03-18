/*
    Copyright 2016 Shane Filiatrault

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
using Storm.StardewValley.Wrapper;

namespace Storm.StardewValley.Event
{
    public class PreSpriteTextDrawStringEvent : StaticContextEvent
    {
        public PreSpriteTextDrawStringEvent(SpriteBatch b, string s, int x, int y, int characterPosition,
            int width, int height, float alpha, float layerDepth, bool junimoText,
            int drawBGScroll, string placeHolderScrollWidthText, int color)
        {
            Sprite = b;
            Text = s;
            X = x;
            Y = y;
            CharacterPosition = characterPosition;
            Width = width;
            Height = height;
            Alpha = alpha;
            LayerDepth = layerDepth;
            JunimoText = junimoText;
            DrawBGScroll = drawBGScroll;
            PlaceHolderScrollWidthText = placeHolderScrollWidthText;
            Color = color;
        }

        public SpriteBatch Sprite { get; }
        public string Text { get; set; }
        public int X { get; }
        public int Y { get; }
        public int CharacterPosition { get; }
        public int Width { get; }
        public int Height { get; }
        public float Alpha { get; }
        public float LayerDepth { get; }
        public bool JunimoText { get; }
        public int DrawBGScroll { get; }
        public string PlaceHolderScrollWidthText { get; }
        public int Color { get; }
    }
}

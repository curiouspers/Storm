/*
    Copyright 2016 Zoey (Zoryn)

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

namespace Storm.StardewValley.Event
{
    public class DrawWithBorderEvent : StaticContextEvent
    {
        public DrawWithBorderEvent(string message, Color borderColor, Color insideColor, Vector2 position, float rotate, float scale, float layerDepth, bool tiny)
        {
            Message = message;
            BorderColor = borderColor;
            InsideColor = insideColor;
            Position = position;
            Rotate = rotate;
            Scale = scale;
            LayerDepth = layerDepth;
            Tiny = tiny;
        }
        public string Message { get; }
        public Color BorderColor { get; }
        public Color InsideColor { get; }
        public Vector2 Position { get; }
        public float Rotate { get; }
        public float Scale { get; }
        public float LayerDepth { get; }
        public bool Tiny { get; }
    }
}

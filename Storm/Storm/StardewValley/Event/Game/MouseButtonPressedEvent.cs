﻿/*
    Copyright 2016 Matt Stevens (Handsome Matt)

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

using Microsoft.Xna.Framework.Input;

namespace Storm.StardewValley.Event
{
    public class MouseButtonPressedEvent : StaticContextEvent
    {
        public enum MouseButton
        {
            Left,
            Middle,
            Right
        }

        public MouseButtonPressedEvent(MouseButton button, MouseState state)
        {
            Button = button;
            State = state;
        }

        public MouseButton Button { get; }
        public MouseState State { get; }
    }
}
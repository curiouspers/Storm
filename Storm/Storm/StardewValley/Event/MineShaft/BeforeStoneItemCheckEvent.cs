﻿/*
    Copyright 2016 TownEater

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

namespace Storm.StardewValley.Event
{
    public class BeforeStoneItemCheckEvent : StaticContextEvent
    {
        public BeforeStoneItemCheckEvent(int tileIndexOfStone, int x, int y, Wrapper.Farmer who)
        {
            TileIndexOfStone = tileIndexOfStone;
            X = x;
            Y = y;
            Who = who;
        }

        public int TileIndexOfStone { get; }

        public int X { get; }

        public int Y { get; }

        public Wrapper.Farmer Who { get; }
    }
}
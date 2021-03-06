﻿/*
    Copyright 2016 Cody R. (Demmonic)

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

using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Storm.StardewValley.Accessor
{
    public interface BuffAccessor
    {
        int _GetMillisecondsDuration();
        void _SetMillisecondsDuration(int val);

        string _GetDescription();
        void _SetDescription(string val);

        string _GetSource();
        void _SetSource(string val);

        int _GetTotal();
        void _SetTotal(int val);

        int _GetSheetIndex();
        void _SetSheetIndex(int val);

        int _GetWhich();
        void _SetWhich(int val);

        Color _GetGlow();
        void _SetGlow(Color val);
    }
}
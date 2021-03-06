﻿/*
    Copyright 2016 Cody R. (Demmonic), Inari-Whitebear

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

using System;
using Microsoft.Xna.Framework.Graphics;
using Storm.StardewValley.Accessor;

namespace Storm.StardewValley.Wrapper
{
    public class Tool : Item
    {
        public Tool(StaticContext parent, ToolAccessor accessor) :
            base(parent, accessor)
        {
        }

        public Tool()
        {
        }

        public ObjectItem[] Attachments
        {
            get { return Array.ConvertAll(Cast<ToolAccessor>()._GetAttachments(), i => new ObjectItem(Parent, i)); }
            set { Cast<ToolAccessor>()._SetAttachments(Array.ConvertAll(value, i => i.Cast<ObjectAccessor>())); }
        }

        /// <summary>
        /// The name of this tool
        /// </summary>
        /// <value>The Name property gets/sets the value of the string field Name</value>
        public string Name
        {
            get { return Cast<ToolAccessor>()._GetName(); }
            set { Cast<ToolAccessor>()._SetName(value); }
        }

        /// <summary>
        /// The description of this tool
        /// </summary>
        /// <value>The Description propertly gets/sets the value of the string field Description</value>
        public new string Description
        {
            get { return Cast<ToolAccessor>()._GetDescription(); }
            set { Cast<ToolAccessor>()._SetDescription(value); }
        }

        public bool IsStackable
        {
            get { return Cast<ToolAccessor>()._GetStackable(); }
            set { Cast<ToolAccessor>()._SetStackable(value); }
        }

        /// <summary>
        /// The upgrade level of this tool
        /// Default = 0
        /// Copper = 1
        /// Iron = 2
        /// Gold = 3
        /// Iridium = 4
        /// </summary>
        /// <value>The UpgradeLevel property sets/gets the value of the int field UpgradeLevel</value>
        public int UpgradeLevel
        {
            get { return Cast<ToolAccessor>()._GetUpgradeLevel(); }
            set { Cast<ToolAccessor>()._SetUpgradeLevel(value); }
        }

        public Texture2D WeaponTexture
        {
            get { return Cast<ToolAccessor>()._GetWeaponsTexture(); }
            set { Cast<ToolAccessor>()._SetWeaponsTexture(value); }
        }

        public Farmer LastUser
        {
            get
            {
                var tmp = Cast<ToolAccessor>()._GetLastUser();
                if (tmp == null) return null;
                return new Farmer(Parent, tmp);
            }
            set { Cast<ToolAccessor>()._SetLastUser(value == null ? null : value.Cast<FarmerAccessor>()); }
        }
    }
}
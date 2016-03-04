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
using Storm.Manipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Storm.ExternalEvent
{
    public struct LoadedMod
    {
        public object instance;
        public Mod annotation;
        public Dictionary<Type, List<MethodInfo>> callMap;
        public string loadDirectory;

        public LoadedMod(object instance, Mod annotation, Dictionary<Type, List<MethodInfo>> callMap)
        {
            this.instance = instance;
            this.annotation = annotation;
            this.callMap = callMap;
            this.loadDirectory = "";
        }

        public string Name { get { return annotation.Name; } }
        public string Author { get { return annotation.Author; } }
        public double Version { get { return annotation.Version; } }
        public string LoadDirectory
        {
            get
            {
                if (instance is DiskResource)
                {
                    return (instance as DiskResource).PathOnDisk;
                }
                return string.Empty;
            }
            set
            {
                if (instance is DiskResource)
                {
                    (instance as DiskResource).PathOnDisk = value;
                }
            }
        }

        public void Fire<T>(T @event) where T : DetourEvent
        {
            List<MethodInfo> handlers;
            if (callMap.TryGetValue(typeof(T), out handlers))
            {
                foreach (var info in handlers)
                {
                    info.Invoke(instance, new object[] { @event });
                }
            }
        }
    }
}
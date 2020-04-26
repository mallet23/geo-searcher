﻿﻿using System.Runtime.InteropServices;

namespace GeoDatabase.Entities
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
    public struct Range
    {
        public uint ip_from; // начало диапазона IP адресов

        public uint ip_to; // конец диапазона IP адресов

        public uint location_index; // индекс записи о местоположении
    }
}
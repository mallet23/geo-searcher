﻿using System.Runtime.InteropServices;

namespace GeoReader.Entities
{
    public class IpRange
    {
        public IpRange(uint from, uint to, uint locationIndex)
        {
            From = from;
            To = to;
            LocationIndex = locationIndex;
        }

        public uint From { get; } // начало диапазона IP адресов

        public uint To { get; } // конец диапазона IP адресов

        public uint LocationIndex { get; } // индекс записи о местоположении
    }
}
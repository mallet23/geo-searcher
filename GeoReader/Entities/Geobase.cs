﻿namespace GeoReader.Entities
{
    internal class Geobase
    {
        public readonly Header Header;
        public readonly IpRange[] IpRanges;
        public readonly Location[] Locations;
        public readonly uint[] Cities;

        public Geobase(Header header, IpRange[] ipRanges, Location[] locations, uint[] cities)
        {
            Header = header;
            IpRanges = ipRanges;
            Locations = locations;
            Cities = cities;
        }
    }
}

﻿namespace GeoReader.Entities
{
    public class Geobase
    {
        public Geobase(Header header, IpRange[] ipRanges, Location[] locations, uint[] cities)
        {
            Header = header;
            IpRanges = ipRanges;
            Locations = locations;
            Cities = cities;
        }
        
        public Header Header { get; }
        public IpRange[] IpRanges { get; }
        public Location[] Locations { get; }
        public uint[] Cities { get; }
    }
}

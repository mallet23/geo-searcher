﻿namespace GeoReader.Entities
{
    public class Geobase
    {
        public Geobase(Header header, IpRange[] ipRanges, Location[] locations, uint[] locationByCityIndexes)
        {
            Header = header;
            IpRanges = ipRanges;
            Locations = locations;
            LocationByCityIndexes = locationByCityIndexes;
        }
        
        public Header Header { get; }
        public IpRange[] IpRanges { get; }
        public Location[] Locations { get; }
        public uint[] LocationByCityIndexes { get; }
    }
}

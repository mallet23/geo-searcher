﻿using System;
using GeoReader.Entities;
using GeoReader.Reader;

 namespace GeoSearcher.Infrastructure
{
    public class GeobaseContext
    {
        private IGeoReader GeoReader { get; }
        private Geobase _geobase;

        public GeobaseContext(IGeoReader reader)
        {
            GeoReader = reader;
            _geobase = GeoReader.Read();
            Locations = _geobase.Locations;
            IpRanges = _geobase.IpRanges;
            LocationSortedByCity = _geobase.LocationByCityIndexes;
        }

        public int Version => _geobase.Header.Version;

        public string Name => _geobase.Header.Name;
        
        public int RecordsCount => _geobase.Header.Records;

        public DateTime Created => _geobase.Header.Timestamp;

        public Location[] Locations { get; }

        public IpRange[] IpRanges { get; }

        public uint[] LocationSortedByCity { get; }
    }
}

using System;
using System.IO;
using GeoReader.Entities;

namespace GeoReader.Reader
{
    public class GeoFileReader: IGeoReader
    {
        
        private readonly BinaryReader _binaryReader;

        public GeoFileReader(Stream stream)
        {
            _binaryReader = new BinaryReader(stream);
        }

        public Geobase Read()
        {
            var header = ReadHeader();
            var ipRanges = ReadIpRanges(header.Records);
            var locations = ReadLocations(header.Records);
            var cities = ReadCities(header.Records);
            
            return new Geobase(header, ipRanges, locations, cities);
        }

        private Header ReadHeader()
        {
            _binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
            return new Header(
                _binaryReader.ReadInt32(),
                _binaryReader.ReadString(),
                DateTime.FromBinary(_binaryReader.ReadInt64()),
                _binaryReader.ReadInt32(),
                _binaryReader.ReadUInt32(),
                _binaryReader.ReadUInt32(),
                _binaryReader.ReadUInt32());
        }

        private IpRange[] ReadIpRanges(int records)
        {
            var ranges = new IpRange[records];
            for (var i = 0; i < records; i++)
            {
                ranges[i] = new IpRange(
                    _binaryReader.ReadUInt32(),
                    _binaryReader.ReadUInt32(),
                    _binaryReader.ReadUInt32());
            }

            return ranges;
        }

        private Location[] ReadLocations(int records)
        {
            var locations = new Location[records];
            for (var i = 0; i < records; i++)
            {
                locations[i] = new Location(
                    _binaryReader.ReadString(),
                    _binaryReader.ReadString(),
                    _binaryReader.ReadString(),
                    _binaryReader.ReadString(),
                    _binaryReader.ReadString(),
                    _binaryReader.ReadSingle(),
                    _binaryReader.ReadSingle());
            }

            return locations;
        }

        private uint[] ReadCities(int records)
        {
            var cities = new uint[records];
            for (var i = 0; i < records; i++)
            {
                cities[i] = _binaryReader.ReadUInt32();
            }

            return cities;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _binaryReader?.Dispose();
            }
        }
    }
}
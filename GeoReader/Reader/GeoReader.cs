using System;
using System.IO;
using GeoReader.Entities;
using GeoReader.Extensions;

namespace GeoReader.Reader
{
    public class GeoReader : IGeoReader, IDisposable
    {
        private readonly BinaryReader _binaryReader;

        public GeoReader(Stream stream)
        {
            _binaryReader = new BinaryReader(stream);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Geobase Read()
        {
            var header = ReadHeader();
            var ipRanges = ReadIpRanges(header.Records);
            var locations = ReadLocations(header.Records);
            var cities = ReadCityNameIndexes(header.Records);

            return new Geobase(header, ipRanges, locations, cities);
        }

        private Header ReadHeader()
        {
            _binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
            return new Header(
                _binaryReader.ReadInt32(),
                _binaryReader.ReadString(32),
                _binaryReader.ReadDateTime(),
                _binaryReader.ReadInt32(),
                _binaryReader.ReadUInt32(),
                _binaryReader.ReadUInt32(),
                _binaryReader.ReadUInt32());
        }

        private IpRange[] ReadIpRanges(int records)
        {
            var ranges = new IpRange[records];
            for (var i = 0; i < records; i++)
                ranges[i] = new IpRange(
                    _binaryReader.ReadUInt32(),
                    _binaryReader.ReadUInt32(),
                    _binaryReader.ReadUInt32());

            return ranges;
        }

        private Location[] ReadLocations(int records)
        {
            var locations = new Location[records];
            for (var i = 0; i < records; i++)
                locations[i] = new Location(
                    _binaryReader.ReadString(8),
                    _binaryReader.ReadString(12),
                    _binaryReader.ReadString(12),
                    _binaryReader.ReadString(24),
                    _binaryReader.ReadString(32),
                    _binaryReader.ReadSingle(),
                    _binaryReader.ReadSingle());

            return locations;
        }

        private uint[] ReadCityNameIndexes(int records)
        {
            var cityNameIndexes = new uint[records];
            for (var i = 0; i < records; i++)
            {
                var offset = _binaryReader.ReadUInt32();
                cityNameIndexes[i] = offset / Location.ByteSize;
            }

            return cityNameIndexes;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _binaryReader?.Dispose();
        }
    }
}
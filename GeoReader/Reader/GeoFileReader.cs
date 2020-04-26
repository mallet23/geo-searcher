using System.IO;
using GeoReader.Entities;

namespace GeoReader.Reader
{
    public class GeoFileReader : IGeoReader
    {
        public GeoFileReader(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }

        public Geobase Read()
        {
            using var stream = File.Open(FileName, FileMode.Open);
            using var reader = new GeoReader(stream);
            return reader.Read();
        }
    }
}
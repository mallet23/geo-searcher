using System.IO;
using GeoReader.Entities;

namespace GeoReader.Reader
{
    public class GeoFileReader : IGeoReader
    {
        public string FileName { get; }
        
        public GeoFileReader(string fileName)
        {
            FileName = fileName;
        }
        
        public Geobase Read()
        {
            using var stream = File.Open(FileName, FileMode.Open);
            using var reader = new GeoReader(stream);
            return reader.Read();
        }
    }
}
using System;
using GeoReader.Entities;

namespace GeoReader.Reader
{
    public interface IGeoReader: IDisposable
    {
        Geobase Read();
    }
}
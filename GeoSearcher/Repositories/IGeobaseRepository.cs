using System.Collections.Generic;
using GeoReader.Entities;

namespace GeoSearcher.Repositories
{
    public interface IGeobaseRepository
    {
        IEnumerable<Location> FindLocationsByCity(string city);

        Location FindLocationByIp(uint ip);
    }
}

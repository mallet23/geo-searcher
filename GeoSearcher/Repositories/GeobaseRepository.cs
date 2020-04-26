using System.Collections.Generic;
using GeoReader.Entities;
using GeoSearcher.Infrastructure;

namespace GeoSearcher.Repositories
{
    public class GeobaseRepository : IGeobaseRepository
    {
        private readonly GeobaseContext _context;

        public GeobaseRepository(GeobaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> FindLocationsByCity(string city)
        {
            var foundIndex = 0;
            var min = 0;
            var max = _context.RecordsCount;

            while (min < max)
            {
                var mid = (min + max) / 2;

                var idx = _context.LocationSortedByCity[mid];
                var location = _context.Locations[idx];

                if (city == location.City)
                {
                    foundIndex = mid;
                    break;
                }

                if (string.CompareOrdinal(city, location.City) < 0)
                    max = mid - 1;
                else
                    min = mid + 1;
            }

            // перечисляем левую часть от найденного
            for (var i = foundIndex; i >= 0; i--)
            {
                var locationIndex = _context.LocationSortedByCity[i];
                if (_context.Locations[locationIndex].City != city) break;

                yield return _context.Locations[locationIndex];
            }

            // перечисляем правую часть от найденного
            for (var i = foundIndex + 1; i < _context.RecordsCount; i++)
            {
                var locationIndex = _context.LocationSortedByCity[i];
                if (_context.Locations[locationIndex].City != city) break;

                yield return _context.Locations[locationIndex];
            }
        }

        public Location FindLocationByIp(uint ip)
        {
            var min = 0;
            var max = _context.RecordsCount;

            while (min < max)
            {
                var mid = (min + max) / 2;

                var range = _context.IpRanges[mid];
                if (ip >= range.From && ip <= range.To)
                    return _context.Locations[range.LocationIndex];

                if (ip < range.From)
                    max = mid - 1;
                else
                    min = mid + 1;
            }

            return null;
        }
    }
}
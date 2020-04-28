using System.Collections.Generic;
using GeoReader.Entities;
using GeoSearcher.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeoSearcher.Controllers
{
    [Route("api/city")]
    public class CityController : GeoBaseController
    {
        public CityController(IGeobaseRepository geobaseRepository) : base(geobaseRepository)
        {
        }

        [HttpGet]
        [Route("{city}/locations")]
        public IEnumerable<Location> GetLocationsByCity(string city)
        {
            return GeobaseRepository.FindLocationsByCity(city);
        }
    }
}
﻿using GeoReader.Entities;
using GeoSearcher.Extensions;
using GeoSearcher.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeoSearcher.Controllers
{
    [Route("ip")]
    public class IpController : GeoBaseController
    {
        public IpController(IGeobaseRepository geobaseRepository) : base(geobaseRepository)
        {
        }

        [HttpGet]
        [Route("location")]
        public Location GetLocationByIp(string ip)
        {
            var ipInt = ip.ConvertIpToInt();
            return GeobaseRepository.FindLocationByIp(ipInt);
        }
    }
}
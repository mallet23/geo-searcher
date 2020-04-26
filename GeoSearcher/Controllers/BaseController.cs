using GeoSearcher.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeoSearcher.Controllers
{
    [Route("api")]
    public class BaseController : Controller
    {
        protected IGeobaseRepository GeobaseRepository { get; }

        public BaseController(IGeobaseRepository geobaseRepository)
        {
            GeobaseRepository = geobaseRepository;
        }
    }
}
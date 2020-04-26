using GeoSearcher.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeoSearcher.Controllers
{
    [Route("api")]
    public class BaseController : Controller
    {
        public BaseController(IGeobaseRepository geobaseRepository)
        {
            GeobaseRepository = geobaseRepository;
        }

        protected IGeobaseRepository GeobaseRepository { get; }
    }
}
using GeoSearcher.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeoSearcher.Controllers
{
    [ApiController]
    public class GeoBaseController : Controller
    {
        public GeoBaseController(IGeobaseRepository geobaseRepository)
        {
            GeobaseRepository = geobaseRepository;
        }

        protected IGeobaseRepository GeobaseRepository { get; }
    }
}
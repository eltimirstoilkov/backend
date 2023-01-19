using Business.Interfaces.v1;
using Business.Models.v1;
using Microsoft.AspNetCore.Mvc;

namespace Vehicles.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownsController : ControllerBase
    {
        private readonly ITownService _townService;

        public TownsController(ITownService townService)
        {
            _townService = townService;
        }


        [HttpGet]
        public IEnumerable<TownResponse> GetAllTowns()
        {
            var towns = _townService.GetAll();
            return towns;
        }

        [HttpGet("{name}")]
        public TownResponse ByName(string name)
        {
            var town = _townService.GetByName(name);
            return town;
        }

        [HttpGet("{id:guid}")]
        public TownInfoModel ById(Guid id) 
        {
            var town = _townService.GetById(id);
            return town;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private static readonly IDictionary<Guid, Car> _idToCar = new Dictionary<Guid, Car>();
        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<Car> GetAll()
        {
            return _idToCar.Select(c => new Car
            {
                Id = c.Key,
                Name = c.Value.Name,
                Number = c.Value.Number
            }).ToList();
        }

        [HttpGet("{id}")]
        public Car GetById(Guid id)
        {
           return _idToCar[id];
        }


        [HttpPost]
        public Car Create(Car car)
        {
            _idToCar[Guid.NewGuid()] = car;
            return car;
        }


        [HttpPut("{id}")]
        public Car Update(Guid id, Car car)
        {
            _idToCar[id] = car;
            return car;
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _idToCar.Remove(id);
        }

    }
}
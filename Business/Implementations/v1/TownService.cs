using AutoMapper;
using Business.Interfaces.v1;
using Business.Models.v1;
using Vehicles.Data.Interfaces.v1;

namespace Business.Implementations.v1
{
    public class TownService : ITownService
    {
        private readonly ITownRepository _townRepository;
        private readonly IMapper _mapper;

        public TownService(ITownRepository townRepository, IMapper mapper)
        {
            _townRepository = townRepository;
            _mapper = mapper;
        }

        public IEnumerable<TownResponse> GetAll()
        {
            //var towns = _townRepository
                

            return null;
        }

        public TownResponse GetByName(string name)
        {
            var town = GetAll()
                .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

            return town;
        }

        public TownInfoModel GetById(Guid id) 
        {
            //var town = _townRepository.
            //    .Where(x => x.Id == id)
            //    .To<TownInfoModel>()
            //    .FirstOrDefault();

            return null ;
        }

    }
}

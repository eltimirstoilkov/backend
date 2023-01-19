using Business.Models.v1;

namespace Business.Interfaces.v1
{
    public interface ITownService
    {
        IEnumerable<TownResponse> GetAll();

        TownResponse GetByName(string name);

        TownInfoModel GetById(Guid id);
    }
}

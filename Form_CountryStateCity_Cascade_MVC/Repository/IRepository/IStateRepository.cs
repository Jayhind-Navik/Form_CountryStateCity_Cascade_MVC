using Form_CountryStateCity_Cascade_MVC.Models;

namespace Form_CountryStateCity_Cascade_MVC.Repository.IRepository
{
    public interface IStateRepository
    {
        IEnumerable<State> GetAll();
        State GetById(int id);
        IEnumerable<State> GetStatesByCountryId(int countryId);
        void Insert(State entity);
        void Update(State entity);
        void Delete(int id);
        void Save();
    }
}

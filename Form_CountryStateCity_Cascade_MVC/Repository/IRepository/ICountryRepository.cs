using Form_CountryStateCity_Cascade_MVC.Models;

namespace Form_CountryStateCity_Cascade_MVC.Repository.IRepository
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country GetById(int id);
        void Insert(Country entity);
        void Update(Country entity);
        void Delete(int id);
        void Save();
    }
}

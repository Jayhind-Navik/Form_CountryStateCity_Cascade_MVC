using Form_CountryStateCity_Cascade_MVC.Models;

namespace Form_CountryStateCity_Cascade_MVC.Repository.IRepository
{
    public interface IApplicationFormRepository
    {
        IEnumerable<ApplicationForm> GetAll();
        ApplicationForm GetById(int id);
        void Insert(ApplicationForm entity);
        void Update(ApplicationForm entity);
        void Delete(int id);
        void Save();
    }
}

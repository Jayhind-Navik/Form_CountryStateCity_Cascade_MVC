using Form_CountryStateCity_Cascade_MVC.Context;
using Form_CountryStateCity_Cascade_MVC.Models;
using Form_CountryStateCity_Cascade_MVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Form_CountryStateCity_Cascade_MVC.Repository.Services
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private readonly AppDbContext _context;

        public ApplicationFormRepository(AppDbContext context) => _context = context;

        public IEnumerable<ApplicationForm> GetAll() => _context.Applications.Include(x => x.Country).Include(x => x.State).ToList();
        public ApplicationForm GetById(int id) => _context.Applications.Find(id);
        public void Insert(ApplicationForm entity) => _context.Applications.Add(entity);
        public void Update(ApplicationForm entity) => _context.Entry(entity).State = EntityState.Modified;
        public void Delete(int id)
        {
            var item = _context.Applications.Find(id);
            if (item != null) _context.Applications.Remove(item);
        }
        public void Save() => _context.SaveChanges();
    }
}

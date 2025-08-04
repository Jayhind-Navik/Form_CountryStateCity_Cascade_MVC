using Form_CountryStateCity_Cascade_MVC.Context;
using Form_CountryStateCity_Cascade_MVC.Models;
using Form_CountryStateCity_Cascade_MVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Form_CountryStateCity_Cascade_MVC.Repository.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context) => _context = context;

        public IEnumerable<Country> GetAll() => _context.Countries.ToList();
        public Country GetById(int id) => _context.Countries.Find(id);
        public void Insert(Country entity) => _context.Countries.Add(entity);
        public void Update(Country entity) => _context.Entry(entity).State = EntityState.Modified;
        public void Delete(int id)
        {
            var item = _context.Countries.Find(id);
            if (item != null) _context.Countries.Remove(item);
        }
        public void Save() => _context.SaveChanges();
    }
}

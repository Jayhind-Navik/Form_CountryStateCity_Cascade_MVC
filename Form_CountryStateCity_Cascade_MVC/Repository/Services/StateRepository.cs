using Form_CountryStateCity_Cascade_MVC.Context;
using Form_CountryStateCity_Cascade_MVC.Models;
using Form_CountryStateCity_Cascade_MVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Form_CountryStateCity_Cascade_MVC.Repository.Services
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;

        public StateRepository(AppDbContext context) => _context = context;

        public IEnumerable<State> GetAll() => _context.States.Include(x => x.Country).ToList();
        public State GetById(int id) => _context.States.Find(id);
        public IEnumerable<State> GetStatesByCountryId(int countryId) => _context.States.Where(x => x.CountryId == countryId).ToList();
        public void Insert(State entity) => _context.States.Add(entity);
        public void Update(State entity) => _context.Entry(entity).State = EntityState.Modified;
        public void Delete(int id)
        {
            var item = _context.States.Find(id);
            if (item != null) _context.States.Remove(item);
        }
        public void Save() => _context.SaveChanges();
    }
}

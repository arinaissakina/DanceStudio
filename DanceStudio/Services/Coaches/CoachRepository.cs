using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceStudio.Data;
using DanceStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace DanceStudio.Services.Coaches
{
    public class CoachRepository : ICoachRepository
    {
        private readonly DanceStudioContext _context;

        public CoachRepository(DanceStudioContext context)
        {
            _context = context;
        }

        public void Add(Coach coach)
        {
            _context.Coaches.Add(coach);
        }

        public void Delete(long id)
        {
            Coach coach = _context.Coaches.Find(id);
            _context.Coaches.Remove(coach);
        }

        public Task<List<Coach>> GetAll()
        {
            return _context.Coaches.ToListAsync();
        }

        public async Task<Coach> GetById(long id)
        {
            return await _context.Coaches.FindAsync(id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Coach coach)
        {
            _context.Entry(coach).State = EntityState.Modified;
        }

        public bool CoachEmailExists(string email)
        {
            if (_context.Coaches.Any(m => m.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }
    }
}
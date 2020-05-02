using System.Collections.Generic;
using System.Threading.Tasks;
using DanceStudio.Models;

namespace DanceStudio.Services.Coaches
{
    public interface ICoachRepository
    {
        Task<List<Coach>> GetAll();
        Task<Coach> GetById(long id);
        void Add(Coach coach);
        void Delete(long id);
        void Update(Coach coach);
        Task Save();
        public bool CoachEmailExists(string email);
    }
}
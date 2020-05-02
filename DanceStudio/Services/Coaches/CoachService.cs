using System.Collections.Generic;
using System.Threading.Tasks;
using DanceStudio.Models;

namespace DanceStudio.Services.Coaches
{
    public class CoachService
    {
        private readonly ICoachRepository _coachRepo;

        public CoachService(ICoachRepository coachRepo)
        {
            _coachRepo = coachRepo;
        }

        public async Task<List<Coach>> GetAll()
        {
            return await _coachRepo.GetAll();
        }

        public async Task<Coach> GetById(long id)
        {
            return await _coachRepo.GetById(id);
        }

        public async Task AddAndSave(Coach coach)
        {
            _coachRepo.Add(coach);
            await _coachRepo.Save();
        }

        public async Task UpdateAndSave(Coach coach)
        {
            _coachRepo.Update(coach);
            await _coachRepo.Save();
        }

        public async Task DeleteAndSave(long id)
        {
            _coachRepo.Delete(id);
            await _coachRepo.Save();
        }
        public bool VerifyEmail(string email)
        {
            return _coachRepo.CoachEmailExists(email);
        }
    }
}
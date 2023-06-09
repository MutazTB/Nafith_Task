using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interfaces;

namespace Repository
{
    public class DigimonRepo : IDigimonRepo
    {
        private readonly DigimonsDbContext _context;
        public DigimonRepo(DigimonsDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<int> AddDigimon(Digimon digimons)
        {
            Response Response = new Response();
            int result = 0;
            _context.Digimons.Add(digimons);
            result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteDigimon(Guid Id)
        {
            int result = 0;
            var digimon = await _context.Digimons.FindAsync(Id);
            if (digimon == null)
            {
                return result;
            }

            _context.Digimons.Remove(digimon);
            result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<Digimon>> GetAllDigimons()
        {
            return await _context.Digimons.ToListAsync();
        }

        public async Task<Digimon> GetDigimon(Guid Id)
        {
            var digimon = await _context.Digimons.FindAsync(Id);
            return digimon;
        }

        public async Task<int> UpdateDigimon(Guid Id, Digimon updatedDigimon)
        {
            int result = 0;
            if (Id != updatedDigimon.Id)
            {
                return result;
            }
            _context.Entry(updatedDigimon).State = EntityState.Modified;
            result = await _context.SaveChangesAsync();
            return result;
        }

    }
}

using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDigimonRepo
    {
        Task<int> AddDigimon(Digimon digimons);
        Task<int> UpdateDigimon(Guid Id, Digimon updatedDigimon);
        Task<int> DeleteDigimon(Guid Id);
        Task<Digimon> GetDigimon(Guid Id);
        Task<IEnumerable<Digimon>> GetAllDigimons();
    }
}
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDigimonSvc
    {
        Task<Response> AddDigimon(Digimon digimons);
        Task<Response> UpdateDigimon(Guid Id, Digimon updatedDigimon);
        Task<Response> DeleteDigimon(Guid Id);
        Task<Response> GetDigimon(Guid Id);
        Task<Response> GetAllDigimons();
    }
}

using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class DigimonSvc : IDigimonSvc
    {
        private readonly IDigimonRepo _DigimonRepo;
        public DigimonSvc(IDigimonRepo digimonRepo)
        {
            _DigimonRepo = digimonRepo;
        }
        public async Task<Response> AddDigimon(Digimon digimons)
        {
            Response response = new Response();

            var result = await _DigimonRepo.AddDigimon(digimons);

            if(result > 0)
            {
                response.Status = Status.Success;                
            }
            else
            {
                response.Status = Status.Error;
                response.ErrorMessage = "Error While adding to database..!";
            }

            return response;
        }

        public async Task<Response> DeleteDigimon(Guid Id)
        {
            Response response = new Response();
            int result = 0;            
            result = await _DigimonRepo.DeleteDigimon(Id);
            if(result > 0)
            {
                response.Status = Status.Success;
            }
            else
            {
                response.Status = Status.Error;
                response.ErrorMessage = "Error While deleting from database..!";
            }
            return response;
        }

        public async Task<Response> GetAllDigimons()
        {
            Response response = new Response();
            List<Digimon> digimons = new List<Digimon>();
            digimons = (List<Digimon>)await _DigimonRepo.GetAllDigimons();

            if(digimons != null || digimons.Count() > 0)
            {
                response.Data = digimons;
                response.Status = Status.Success;
            }
            else
            {
                response.Status = Status.Error;
                response.ErrorMessage = "No Digimons in database...";
                response.Data = null;
            }
            return response;
        }

        public async Task<Response> GetDigimon(Guid Id)
        {
            Response response = new Response();
            Digimon digimon = new Digimon();
            digimon = await _DigimonRepo.GetDigimon(Id);
            if(digimon != null)
            {
                response.Status = Status.Success;
                response.Data = digimon;
            }
            else
            {
                response.Status= Status.Error;
                response.ErrorMessage = "Can not found selected Digimon...";
            }
            return response;
        }

        public async Task<Response> UpdateDigimon(Guid Id, Digimon updatedDigimon)
        {
            Response response = new Response();
            int result = 0;            
            result = await _DigimonRepo.UpdateDigimon(Id, updatedDigimon);
            if (result > 0)
            {
                response.Status = Status.Success;
            }
            else
            {
                response.Status = Status.Error;
                response.ErrorMessage = "Error While adding to database..!";
            }
            return response;
        }

    }
}

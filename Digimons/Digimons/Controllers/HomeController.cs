using Digimons.Models;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Diagnostics;
using System.Text.Json;

namespace Digimons.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDigimonSvc _digimonSvc;

        public HomeController( IHttpClientFactory httpClientFactory, IDigimonSvc digimonSvc)
        {
            _httpClientFactory = httpClientFactory;
            _digimonSvc = digimonSvc;
        }

        public async Task<ActionResult<IEnumerable<Digimon>>> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://digimon-api.vercel.app/api/digimon");

                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var digimons = await JsonSerializer.DeserializeAsync<IEnumerable<Digimon>>(responseStream, options);


                    if (digimons != null)
                    {
                        // You can perform additional mapping or manipulation of the data if needed
                        return View(digimons);
                    }
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                return StatusCode(500, "An error occurred while retrieving Digimon data.");
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Response>> AddDigimon(Digimon digimon)
        {
            Response response = new Response();

            response = await _digimonSvc.AddDigimon(digimon);

            return response;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Response>> DeleteDigimon(Guid Id)
        {
            Response response = new Response();

            response = await _digimonSvc.DeleteDigimon(Id);

            return response;
        }
        
        [Authorize]
        public async Task<ActionResult> Update(Guid Id)
        {
            Response response = new Response();
            Digimon digimon = new Digimon();
            response = await _digimonSvc.GetDigimon(Id);
            digimon = (Digimon)response.Data;
            return View(digimon);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> UpdateDigimon(Guid Id, Digimon digimon)
        {
            Response response = new Response();
            try
            {
                response = await _digimonSvc.UpdateDigimon(Id , digimon);                
            }
            catch (Exception)
            {
                // Log and handle the exception
                return StatusCode(500, "An error occurred while updating the Digimon.");
            }
            return RedirectToAction(nameof(Favorite));
        }

        [Authorize]
        public async Task<ActionResult<IEnumerable<Digimon>>> Favorite()
        {
            Response response = new Response();
            IEnumerable<Digimon> digimons = new List<Digimon>();
            response = await _digimonSvc.GetAllDigimons();
            digimons = (IEnumerable<Digimon>)response.Data;
            return View(digimons);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
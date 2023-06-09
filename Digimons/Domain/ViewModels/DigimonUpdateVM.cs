using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class DigimonUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DigimonApiResponse
    {
        public IEnumerable<DigimonAPI> Digimons { get; set; }
    }

    public class DigimonAPI
    {
        public string Name { get; set; }

        public string Img { get; set; }

        public string Level { get; set; }
    }
}

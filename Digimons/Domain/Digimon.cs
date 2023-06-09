using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Digimon
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Img { get; set; }

        public string Level { get; set; }
    }
}

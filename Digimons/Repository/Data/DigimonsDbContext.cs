using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class DigimonsDbContext : IdentityDbContext<ApplicationUser>
    {
        public DigimonsDbContext(DbContextOptions<DigimonsDbContext> options) : base(options)
        {
        }

        public DbSet<Digimon> Digimons { get; set; }
    }
}

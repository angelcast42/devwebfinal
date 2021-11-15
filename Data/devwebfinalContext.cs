using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using devwebfinal.Models;

namespace devwebfinal.Data
{
    public class devwebfinalContext : DbContext
    {
        public devwebfinalContext (DbContextOptions<devwebfinalContext> options)
            : base(options)
        {
        }

        public DbSet<devwebfinal.Models.Catedraticos> Catedraticos { get; set; }

        public DbSet<devwebfinal.Models.Cursos> Cursos { get; set; }
    }
}

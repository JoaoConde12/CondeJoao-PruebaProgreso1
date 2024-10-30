using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CondeJoao_PruebaProgreso1.Models;

namespace CondeJoao_PruebaProgreso1.Data
{
    public class CondeJoao_PruebaProgreso1Context : DbContext
    {
        public CondeJoao_PruebaProgreso1Context (DbContextOptions<CondeJoao_PruebaProgreso1Context> options)
            : base(options)
        {
        }

        public DbSet<CondeJoao_PruebaProgreso1.Models.Conde> Conde { get; set; } = default!;
    }
}

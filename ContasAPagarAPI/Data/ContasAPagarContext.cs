using ContasAPagarAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContasAPagarAPI.Data
{
    public class ContasAPagarContext : DbContext
    {
        public ContasAPagarContext(DbContextOptions<ContasAPagarContext> opcoes) : base(opcoes)
        {

        }

        public DbSet<ContaPaga> Contas { get; set; }
    }
}

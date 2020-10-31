using ContasAPagarAPI.Models;
using Microsoft.EntityFrameworkCore;

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

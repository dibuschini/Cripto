using Dimensiona.Models;
using Microsoft.EntityFrameworkCore;

namespace Dimensiona.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
        }
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<DimensionamentoModel> Dimensionamentos { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplicationTeste.Model;

namespace WebApplicationTeste.Data
{
    public class WebApiTesteDesafioContext : DbContext
    {
        public WebApiTesteDesafioContext(DbContextOptions<WebApiTesteDesafioContext> options)
            : base(options)
        {
        }

        public DbSet<Morador> Morador { get; set; }

        public DbSet<Apartamento> Apartamento { get; set; }

        public DbSet<Bloco> Bloco { get; set; }

        public DbSet<Condominio> Condominio { get; set; }
    }
}

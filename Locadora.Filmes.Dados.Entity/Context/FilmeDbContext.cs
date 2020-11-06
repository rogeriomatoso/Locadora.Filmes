using Locadora.Filmes.Dados.Entity.TypeConfiguration;
using Locadora.Filmes.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Filmes.Dados.Entity.Context
{
    public class FilmeDbContext : DbContext
    {
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        public FilmeDbContext()//construtor apenas para otimizar o processamento das migrations
                               //porém é dispensável.
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumTypeConfiguration());
            modelBuilder.Configurations.Add(new FilmeTypeConfiguration());
        }      
    }
}

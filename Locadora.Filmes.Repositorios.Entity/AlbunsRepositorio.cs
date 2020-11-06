using Locadora.Filmes.Dados.Entity.Context;
using Locadora.Filmes.Dominio;
using Locadora.Repositorios.Comum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Locadora.Filmes.Repositorios.Entity
{
    public class AlbunsRepositorio : RepositorioGenericoEntity<Album, int>
    {
        public AlbunsRepositorio(FilmeDbContext contexto)
            : base(contexto)
        {

        }

        public override List<Album> Selecionar()
        {
            return _contexto.Set<Album>().Include(p => p.Filmes).ToList();
        }

        public override Album SelecionarPorId(int id)
        {
            return _contexto.Set<Album>().Include(p => p.Filmes)
                .SingleOrDefault(a => a.Id == id);
        }
    }
}

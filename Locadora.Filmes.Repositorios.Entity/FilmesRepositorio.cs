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
    public class FilmesRepositorio : RepositorioGenericoEntity<Filme, long>        
    {
        public FilmesRepositorio(FilmeDbContext contexto)
            : base(contexto)
        {

        }

        public override List<Filme> Selecionar()
        {
            return _contexto.Set<Filme>().Include(p=> p.Album).ToList();
        }

        public override Filme SelecionarPorId(long id)
        {
            return _contexto.Set<Filme>().Include(p=>p.Album)
                .SingleOrDefault(f=>f.IdFilme == id);
        }
    }
}

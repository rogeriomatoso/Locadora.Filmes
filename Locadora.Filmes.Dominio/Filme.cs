using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Filmes.Dominio
{
    public class Filme
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public virtual Album abum { get; set; }
        public int IdAlbum { get; set; }

    }
}

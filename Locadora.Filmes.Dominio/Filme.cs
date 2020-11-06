using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Filmes.Dominio
{
    public class Filme
    {
        public long IdFilme { get; set; }
        public string NomeFilme { get; set; }
        public virtual Album Album { get; set; }
        public int IdAlbum { get; set; }

    }
}

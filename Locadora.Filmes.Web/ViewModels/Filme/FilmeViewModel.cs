using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Filmes.Web.ViewModels.Filme
{
    public class FilmeViewModel
    {
        [Required(ErrorMessage ="O Id não pode ficar em branco")]
        public long IdFilme { get; set; }


        [Display(Name = "Nome do Filme")]
        [Required(ErrorMessage ="Preencha o nome do Filme")]
        [MaxLength(100, ErrorMessage ="O nome do filme deve ter no maximo 100 caracteres.")]
        public string NomeFilme { get; set; }


        [Display(Name = "Nome do Album")]
        [Required(ErrorMessage ="Selecione um álbum!")]
        public int IdAlbum { get; set; }
    }
}
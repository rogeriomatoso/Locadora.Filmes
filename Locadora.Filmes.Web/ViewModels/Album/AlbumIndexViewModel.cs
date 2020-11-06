using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Filmes.Web.ViewModels.Album
{
    public class AlbumIndexViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Nome do Album")]
        public string Nome { get; set; }


        [Display(Name = "Ano do Album")]
        public int Ano { get; set; }


        [Display(Name = "Descrição do Album")]
        public string Descricao { get; set; }


        [Display(Name = "Autor do Album")]
        public string Autor { get; set; }


        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}
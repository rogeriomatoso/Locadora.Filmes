using Locadora.Filmes.Web.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Filmes.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        [Required(ErrorMessage ="O Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do album é obrigatório")]
        [MaxLength(100, ErrorMessage ="O nome deve ter no maximo 100 caracteres")]
        [Display(Name = "Nome do Album")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O ano é obrigatorio")]
        [Display(Name = "Ano do Album")]
        public int Ano { get; set; }

        //[Required(ErrorMessage = "A descrição é obrigatória")]
        [MaxLength(1000, ErrorMessage = "Descrição deve ter no maximo 1000 caracteres")]
        [Display(Name = "Descrição do Album")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O autor do album é obrigatório")]
        [MaxLength(100, ErrorMessage = "Nome do autor deve ter no maximo 100 caracteres")]
        [Display(Name = "Autor do Album")]
        public string Autor { get; set; }

        [Display(Name ="E-mail para Contato")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email é obrigatorio")]
        [Email(ErrorMessage ="O dominio do email deve ser o @unipam.edu.br")]
        public string Email { get; set; }
    }
}
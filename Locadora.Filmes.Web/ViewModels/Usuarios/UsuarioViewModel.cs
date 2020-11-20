using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Filmes.Web.ViewModels.Usuarios
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="E-mail é oobrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Senha é obrigatoria.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
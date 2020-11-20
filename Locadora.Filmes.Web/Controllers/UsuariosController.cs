using Locadora.Filmes.Dados.Entity.Context;
using Locadora.Filmes.Web.Identity;
using Locadora.Filmes.Web.ViewModels.Usuarios;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Locadora.Filmes.Web.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult CriarUsuario()
        {
            return View();
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CriarUsuario(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<IdentityUser>(new FilmeIdentityDbContext());
                var userManage = new UserManager<IdentityUser>(userStore);
                var identityUser = new IdentityUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email

                };

                IdentityResult resultado = userManage.Create(identityUser, viewModel.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("erro_identity", resultado.Errors.First());
                    return View(viewModel);
                }

            }
            return View(viewModel);

        }     
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View(viewModel);
        }
    } 
}


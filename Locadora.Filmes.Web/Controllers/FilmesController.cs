using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Locadora.Filmes.Dados.Entity.Context;
using Locadora.Filmes.Dominio;
using Locadora.Filmes.Repositorios.Comum;
using Locadora.Filmes.Repositorios.Entity;
using Locadora.Filmes.Web.ViewModels.Album;
using Locadora.Filmes.Web.ViewModels.Filme;

namespace Locadora.Filmes.Web.Controllers
{
    public class FilmesController : Controller
    {
        private IRepositorioGenerico<Filme, long>
            repositorioFilmes = new FilmesRepositorio(new FilmeDbContext());

        private IRepositorioGenerico<Album, int>
            repositorioAlbuns = new AlbunsRepositorio(new FilmeDbContext());

        // GET: Filmes
        public ActionResult Index()
        {
           // var filmes = db.Filmes.Include(f => f.Album);
            return View(Mapper.Map<List<Filme>, 
                         List<FilmeIndexViewModel>>(repositorioFilmes.Selecionar()));
        }

        // GET: Filmes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = repositorioFilmes.SelecionarPorId(id.Value);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Filme, FilmeIndexViewModel>(filme));
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            // ViewBag.IdAlbum = new SelectList(db.Albuns, "Id", "Nome");
            List<AlbumIndexViewModel> albuns = Mapper.Map<List<Album>,
                 List<AlbumIndexViewModel>>(repositorioAlbuns.Selecionar());

            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");

            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View();
        }

        // POST: Filmes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFilme,NomeFilme,IdAlbum")] FilmeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Filme filme = Mapper.Map<FilmeViewModel, Filme>(viewModel);
                repositorioFilmes.Inserir(filme);
                return RedirectToAction("Index");
            }

           //ViewBag.IdAlbum = new SelectList(db.Albuns, "Id", "Nome", filme.IdAlbum);
            return View(viewModel);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = repositorioFilmes.SelecionarPorId(id.Value);
            if (filme == null)
            {
                return HttpNotFound();
            }
            // ViewBag.IdAlbum = new SelectList(db.Albuns, "Id", "Nome", filme.IdAlbum);

            List<AlbumIndexViewModel> albuns = Mapper.Map<List<Album>,
                 List<AlbumIndexViewModel>>(repositorioAlbuns.Selecionar());

            SelectList dropDownAlbuns = new SelectList(albuns, "Id", "Nome");

            ViewBag.DropDownAlbuns = dropDownAlbuns;
            return View(Mapper.Map<Filme, FilmeViewModel>(filme)); 
        }

        // POST: Filmes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFilme,NomeFilme,IdAlbum")] FilmeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Filme filme = Mapper.Map<FilmeViewModel, Filme>(viewModel);
                repositorioFilmes.Alterar(filme);
                return RedirectToAction("Index");
            }
            //ViewBag.IdAlbum = new SelectList(db.Albuns, "Id", "Nome", filme.IdAlbum);
            return View(viewModel);
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = repositorioFilmes.SelecionarPorId(id.Value);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Filme, FilmeIndexViewModel>(filme));
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioFilmes.ExcluirPorId(id);
            return RedirectToAction("Index");
        }       
    }
}

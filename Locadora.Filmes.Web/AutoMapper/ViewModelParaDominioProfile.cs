using AutoMapper;
using Locadora.Filmes.Dominio;
using Locadora.Filmes.Web.ViewModels.Album;
using Locadora.Filmes.Web.ViewModels.Filme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora.Filmes.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AlbumViewModel, Album>();
            Mapper.CreateMap<FilmeViewModel, Filme>();
        }
    }
}
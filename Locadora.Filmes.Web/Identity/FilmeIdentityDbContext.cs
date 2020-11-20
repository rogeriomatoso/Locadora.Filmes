using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora.Filmes.Web.Identity
{
    public class FilmeIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public FilmeIdentityDbContext()
            :base("FilmeDbContext")
        {
            
        }

    }
}
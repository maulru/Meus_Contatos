using Meus_Contatos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meus_Contatos.Data
{
    public class UsuarioDbContext : IdentityDbContext<Usuario>
    {
        public UsuarioDbContext
            (DbContextOptions<UsuarioDbContext> opts) : base(opts)
        {

        }
    }
}

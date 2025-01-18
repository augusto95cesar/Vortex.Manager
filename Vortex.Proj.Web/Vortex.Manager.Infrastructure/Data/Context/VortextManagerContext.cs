using Microsoft.EntityFrameworkCore;
using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Infrastructure.Data.Context
{
    public class VortextManagerContext : DbContext
    {
        public VortextManagerContext(DbContextOptions<VortextManagerContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoticiaTag> NoticiaTags { get; set; }
        public DbSet<Noticia> Noticias { get; set; }         
    }
}

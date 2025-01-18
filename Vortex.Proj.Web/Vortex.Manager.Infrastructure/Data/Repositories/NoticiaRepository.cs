using Microsoft.EntityFrameworkCore;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Context;
using Vortex.Manager.Infrastructure.Data.Interfaces;

namespace Vortex.Manager.Infrastructure.Data.Repositories
{
    public class NoticiaRepository : INoticiaRepository
    {
        private VortextManagerContext _context;
        private DbSet<Noticia> _dbSet;

        public NoticiaRepository(VortextManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<Noticia>();
        }

        public async Task<Noticia> AddAsync(Noticia entrada)
        {
            await _dbSet.AddAsync(entrada);
            await _context.SaveChangesAsync();
            return entrada;
        } 
    }
}

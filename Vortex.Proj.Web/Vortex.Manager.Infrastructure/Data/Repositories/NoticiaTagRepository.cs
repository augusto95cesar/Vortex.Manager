using Microsoft.EntityFrameworkCore;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Context;
using Vortex.Manager.Infrastructure.Data.Interfaces;

namespace Vortex.Manager.Infrastructure.Data.Repositories
{
    public class NoticiaTagRepository : INoticiaTagRepository
    {
        private VortextManagerContext _context;
        private DbSet<NoticiaTag> _dbSet;

        public NoticiaTagRepository(VortextManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<NoticiaTag>();
        }

        public async Task<NoticiaTag> AddAsync(NoticiaTag entrada)
        {
            await _dbSet.AddAsync(entrada);
            await _context.SaveChangesAsync();
            return entrada; 
        } 
    }
}

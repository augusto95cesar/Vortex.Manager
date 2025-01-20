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

        public async Task<NoticiaTag> AddAsync(NoticiaTag noticiaTag)
        {
            await _dbSet.AddAsync(noticiaTag);
            await _context.SaveChangesAsync();
            return noticiaTag;
        }

        public async Task RemoveNoticiaAll(int noticiaId)
        {
            var tagsNoticias = await _dbSet.Where(p => p.NoticiaId == noticiaId).ToListAsync();

            if (tagsNoticias.Count > 0)
            {
                _dbSet.RemoveRange(tagsNoticias);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveTagAll(int tagId)
        {
            var tagsNoticias = await _dbSet.Where(p => p.TagId == tagId).ToListAsync();

            if (tagsNoticias.Count > 0)
            {
                _dbSet.RemoveRange(tagsNoticias);
                await _context.SaveChangesAsync();
            }
        }
    }
}

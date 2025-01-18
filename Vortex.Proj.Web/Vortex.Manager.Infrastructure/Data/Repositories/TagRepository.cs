using Microsoft.EntityFrameworkCore;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Context;
using Vortex.Manager.Infrastructure.Data.Interfaces;

namespace Vortex.Manager.Infrastructure.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private VortextManagerContext _context;
        private DbSet<Tag> _dbSet;

        public TagRepository(VortextManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<Tag>();
        }

        public async Task<Tag> AddAsync(Tag entrada)
        {
            await _dbSet.AddAsync(entrada);
            await _context.SaveChangesAsync();
            return entrada;
        }

        public async Task<List<Tag>> GetALLAsync()
        { 
            return await _dbSet.ToListAsync();
        }

        public async Task<List<Tag>> GetAsync(List<int> entrada)
        {
            return await _dbSet.Where(p => entrada.Contains(p.Id)).ToListAsync();
        } 
    }
}

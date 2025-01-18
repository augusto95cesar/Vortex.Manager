using Microsoft.EntityFrameworkCore;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Context;
using Vortex.Manager.Infrastructure.Data.Interfaces;

namespace Vortex.Manager.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private VortextManagerContext _context;
        private DbSet<Usuario> _dbSet;

        public UsuarioRepository(VortextManagerContext context)
        {
            _context = context;
            _dbSet = context.Set<Usuario>();
        }

        public async Task<Usuario> AddAsync(Usuario user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Usuario?> GetAsync(Usuario user)
        {
            return await _dbSet.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
        }
    }
}

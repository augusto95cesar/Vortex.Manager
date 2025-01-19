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

        /// <summary>
        /// Add Noticia Criada por User Logado
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public async Task<Noticia> AddAsync(Noticia entrada)
        {
            await _dbSet.AddAsync(entrada);
            await _context.SaveChangesAsync();
            return entrada;
        }

        /// <summary>
        /// Get All Noticias do User Logado.
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<List<Noticia>> GetAllAsync(int idUser)
        {
            return await _dbSet.Where(n => n.UsuarioId == idUser)
                               .Include(n => n.NoticiaTag) // Inclui a tabela intermediária
                               .ThenInclude(nt => nt.Tag)  // Inclui a tabela Tag
                               .ToListAsync();  
        }

        /// <summary>
        /// Get Noticia.
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<Noticia?> GetAsync(int idNoticia)
        {
            return await _dbSet.Where(n => n.Id == idNoticia)
                              .Include(n => n.NoticiaTag) // Inclui a tabela intermediária
                              .ThenInclude(nt => nt.Tag)  // Inclui a tabela Tag
                              .FirstOrDefaultAsync();
        }
    }
}

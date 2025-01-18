using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Interfaces;

namespace Vortex.Manager.Application.Services
{
    public class NoticiaService : INoticiaService
    {
        private INoticiaRepository _noticiaRepository;

        public NoticiaService(INoticiaRepository noticiaRepository)
        {
            _noticiaRepository = noticiaRepository;
        }
        public async Task<Noticia> AddAsync(Noticia noticia)
        {
            return await _noticiaRepository.AddAsync(noticia);
        }
    }
}

using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Interfaces;

namespace Vortex.Manager.Application.Services
{
    public class NoticiaService : INoticiaService
    {
        private INoticiaRepository _noticiaRepository;
        private IUsuarioService _usuarioService;

        public NoticiaService(INoticiaRepository noticiaRepository, IUsuarioService usuarioService)
        {
            _noticiaRepository = noticiaRepository;
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Add Noticia Criada por User Logado
        /// </summary>
        /// <param name="noticia"></param>
        /// <returns></returns>
        public async Task<Noticia> AddAsync(Noticia noticia)
        {
            return await _noticiaRepository.AddAsync(noticia);
        }

        /// <summary>
        /// Get All Noticias do User Logado.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Noticia>> GetAsync()
        {
            var usuarioLogado = await _usuarioService.GetUserLogado(); 
            return await _noticiaRepository.GetAllAsync(usuarioLogado.Id);
        }

        /// <summary>
        /// Get Noticia.
        /// </summary>
        /// <returns></returns>
        public async Task<Noticia?> GetAsync(int idNoticia)
        {
            return await _noticiaRepository.GetAsync(idNoticia);
        }

        public async Task RemoveAsync(int idNoticia)
        {
            await _noticiaRepository.RemoveAsync(idNoticia);
        }

        public async Task<Noticia> UpdateAsync(Noticia entrada)
        {
            return await _noticiaRepository.UpdateAsync(entrada);
        }
    }
}

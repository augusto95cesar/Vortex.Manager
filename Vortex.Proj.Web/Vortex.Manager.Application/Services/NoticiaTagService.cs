using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Interfaces;

namespace Vortex.Manager.Application.Services
{
    public class NoticiaTagService : INoticiaTagService
    {
        private INoticiaTagRepository _noticiaTagRepository;

        public NoticiaTagService(INoticiaTagRepository noticiaTagRepository)
        {
            _noticiaTagRepository = noticiaTagRepository;
        }
        public async Task AddAsync(List<NoticiaTag> noticiaTag)
        {
            foreach (var item in noticiaTag) 
                await _noticiaTagRepository.AddAsync(item); 
        }

        public async Task RemoveAll(int noticiaId)
        {
            await _noticiaTagRepository.RemoveAll(noticiaId);
        }
    }
}

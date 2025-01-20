using Vortex.Manager.Application.Interfaces.Services;
using Vortex.Manager.Domain.Entity;
using Vortex.Manager.Infrastructure.Data.Interfaces;

namespace Vortex.Manager.Application.Services
{
    public class TagsService : ITagsService
    {
        private ITagRepository _repository;

        public TagsService(ITagRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<Tag>> GetALLAsync()
        {
            return await _repository.GetALLAsync();
        }

        public async Task<Tag> AddAsync(Tag entrada)
        {
            return await _repository.AddAsync(entrada);
        }

        public async Task<Tag> UpdateAsync(Tag entrada)
        {
            return await _repository.UpdateAsync(entrada);
        }

        public async Task RemoveAsync(int idTag)
        {
            await _repository.RemoveAsync(idTag);
        }
    }
}

using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Interfaces.Services
{
    public interface ITagsService
    {
        Task<Tag> AddAsync(Tag entrada);
        Task<List<Tag>> GetALLAsync();
        Task<List<Tag>> GetAsync(List<int> entrada);
    }
}

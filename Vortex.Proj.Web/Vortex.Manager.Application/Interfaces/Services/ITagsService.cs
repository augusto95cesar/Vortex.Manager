using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Application.Interfaces.Services
{
    public interface ITagsService
    {
        Task<Tag> AddAsync(Tag entrada);
        Task<Tag> UpdateAsync(Tag entrada);
        Task<List<Tag>> GetALLAsync();
        Task RemoveAsync(int entrada);
    }
}

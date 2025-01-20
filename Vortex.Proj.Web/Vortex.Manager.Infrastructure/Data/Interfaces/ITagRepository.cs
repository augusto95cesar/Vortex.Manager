using Vortex.Manager.Domain.Entity;

namespace Vortex.Manager.Infrastructure.Data.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> AddAsync(Tag entrada);
        Task<Tag> UpdateAsync(Tag entrada);
        Task<List<Tag>> GetALLAsync();
        Task<List<Tag>> GetAsync(List<int> entrada);
        Task RemoveAsync(int entrada);
    }
}

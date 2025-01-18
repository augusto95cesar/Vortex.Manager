namespace Vortex.Manager.Application.Interfaces
{
    public interface IHandler<TInput, TOutput>
    { 
        Task<TOutput> ExecutarAsync(TInput entrada);
    }
}

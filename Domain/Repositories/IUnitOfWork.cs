using System.Threading.Tasks;

namespace BackendData.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompletedAsync();
    }
}

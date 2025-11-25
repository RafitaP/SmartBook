using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
using System.Threading.Tasks;

namespace ECE.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

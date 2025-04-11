using ECE.Core.DomainObjets;
using System;

namespace ECE.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork unitOfWork { get; }
    }
}

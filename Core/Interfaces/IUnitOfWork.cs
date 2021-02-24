using System;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISchoolRepository Schools { get; }
        IDepartmentRepository Department { get; }
        Task<int> CompleteAsync();
    }
}
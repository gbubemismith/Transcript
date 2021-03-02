using System.Threading.Tasks;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TranscriptContext _context;
        public UnitOfWork(TranscriptContext context)
        {
            _context = context;
            Schools = new SchoolRepository(_context);
            Department = new DepartmentRepository(_context);

        }

        public ISchoolRepository Schools { get; private set; }
        public IDepartmentRepository Department { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
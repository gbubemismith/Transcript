using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<SchoolDepartment>
    {
        Task<IReadOnlyList<SchoolDepartment>> GetBySchoolId(int schoolId);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.services
{
    public interface ISchoolManagementService
    {
        Task<School> GetSchoolById(int id);
        Task<IReadOnlyList<School>> GetAllSchools();
        Task<IReadOnlyList<SchoolDepartment>> GetDepartmentsBySchoolId(int schoolId);

    }
}
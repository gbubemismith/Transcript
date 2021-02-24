using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DepartmentRepository : GenericRespository<SchoolDepartment>, IDepartmentRepository
    {
        public DepartmentRepository(TranscriptContext context) : base(context)
        {

        }

        public async Task<IReadOnlyList<SchoolDepartment>> GetBySchoolId(int schoolId)
        {
            return await _context.SchoolDepartment
                        .Where(d => d.SchoolId == d.SchoolId).ToListAsync();
        }
    }
}
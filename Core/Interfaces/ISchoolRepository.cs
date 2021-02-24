using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ISchoolRepository : IGenericRepository<School>
    {
        Task<School> GetSchoolByName(string name);

    }
}

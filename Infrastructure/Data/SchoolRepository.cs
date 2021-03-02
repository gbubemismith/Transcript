using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SchoolRepository : GenericRespository<School>, ISchoolRepository
    {
        public SchoolRepository(TranscriptContext context) : base(context)
        {

        }

        public Task<School> GetSchoolByName(string name)
        {
            return _context.School.FirstOrDefaultAsync(s => s.Name == name);
        }


        //another way
        // public TranscriptContext TranscriptContext
        // {
        //     get { return _context as TranscriptContext; }
        // }
    }
}
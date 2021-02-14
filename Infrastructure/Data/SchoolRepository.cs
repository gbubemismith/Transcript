using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class SchoolRepository : GenericRespository<School>, ISchoolRepository
    {
        public SchoolRepository(TranscriptContext context) : base(context)
        {

        }

        public void Check()
        {
            // _context.School.Where(p => p.)
        }

        //another way
        // public TranscriptContext TranscriptContext
        // {
        //     get { return _context as TranscriptContext; }
        // }
    }
}
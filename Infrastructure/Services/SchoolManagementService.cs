using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.services;

namespace Infrastructure.Services
{
    public class SchoolManagementService : ISchoolManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SchoolManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<School> GetSchoolById(int id)
        {
            return await _unitOfWork.Schools.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<School>> GetAllSchools()
        {
            return await _unitOfWork.Schools.GetAllAsync();

        }

        public async Task<IReadOnlyList<SchoolDepartment>> GetDepartmentsBySchoolId(int schoolId)
        {
            return await _unitOfWork.Department.GetBySchoolId(schoolId);
        }

        public async Task<School> CreateSchool(School school)
        {
            _unitOfWork.Schools.Add(school);
            await _unitOfWork.CompleteAsync();

            return school;
        }
    }
}
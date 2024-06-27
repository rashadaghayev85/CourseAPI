using Domain.Entities;
using Service.DTOs.Groups;
using Service.DTOs.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateAsync(StudentCreateDto model);
        Task<IEnumerable<Student>> GetAllWithAsync();

        Task<StudentDto> GetByIdAsync(int id);
        Task DeleteAsync(int id);

        Task EditAsync(int id, StudentEditDto model);
    }
}

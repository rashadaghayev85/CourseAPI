using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Student>> GetAllWithAsync()
        {
            return await _context.Students.AsNoTracking().Include(m => m.GroupStudents).ToListAsync();
        }

        public async Task<Student> GetByIdWithAsync( int? id)
        {
            if (id == null) { throw new ArgumentNullException(nameof(id)); }
            var data = await _context.Students.AsNoTracking().Include(m=>m.GroupStudents).FirstOrDefaultAsync(m => m.Id==id);  
            return data;
        }
        
    }
}

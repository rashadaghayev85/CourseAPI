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
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Group>> GetAllWithAsync()
        {
            return await _context.Groups.AsNoTracking().Include(m => m.GroupStudents).ToListAsync();
        }

        public async Task<List<Group>> GetByIdWithAsync22(List<int>? id)
        {

            if (id == null)  throw new ArgumentNullException(nameof(id));
            List<Group> groups = new();
           foreach (var item in id)
            {
                if (!await _context.Groups.AnyAsync(g => g.Id == item))
                {
                throw new NullReferenceException(nameof(item)); 

                }
                else
                {
                    groups.Add(await _context.Groups.AsNoTracking().FirstOrDefaultAsync(m=>m.Id==item));
                }
            }

            
            return groups;
        }
        public async Task<GroupStudent> GetByIdAsync11(int ? id)
        {
            if (id == null) { throw new ArgumentNullException(nameof(id)); }
            var data = await _context.GroupStudents.AsNoTracking().Include(m => m.Group).FirstOrDefaultAsync(m => m.GroupId.Equals(id));
            return data;
        }

        public Task<GroupStudent> GetByIdWithAsync(List<int>? id)
        {
            throw new NotImplementedException();
        }
    }
}

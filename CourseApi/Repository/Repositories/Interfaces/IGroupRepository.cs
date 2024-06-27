using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<GroupStudent> GetByIdWithAsync(List<int>? id);
        Task<IEnumerable<Group>> GetAllWithAsync();
        Task<GroupStudent> GetByIdAsync11(int? id);
        Task<List<Group>> GetByIdWithAsync22(List<int>? id);
    }
}

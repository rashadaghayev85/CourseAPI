using Domain.Entities;
using Service.DTOs.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task CreateAsync(GroupCreateDto model);
        Task<IEnumerable<Group>> GetAllWithAsync();

        Task<GroupDto> GetByIdAsync(int? id);
        Task DeleteAsync(int id);

        Task EditAsync(int id, GroupEditDto model);
        Task<List<GroupDto>> GetById(List<int>? id);
    }
}

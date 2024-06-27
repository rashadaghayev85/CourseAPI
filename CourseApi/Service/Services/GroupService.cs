using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Groups;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;

        public GroupService(IMapper mapper,
                           IGroupRepository groupRepo,
                           IStudentRepository studentRepo,
                           ILogger<StudentService> logger)

        {

            _mapper = mapper;
            _groupRepo = groupRepo;
            _studentRepo = studentRepo;
            _logger = logger;
        }
        public async Task CreateAsync(GroupCreateDto model)
        {
            if (model == null) throw new ArgumentNullException();
          model.StudentCount++;
            await _groupRepo.CreateAsync(_mapper.Map<Group>(model));
        }

        public async Task DeleteAsync(int id)
        {
            if (id==null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }
            var data = await _groupRepo.GetById((int)id);
            await _groupRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, GroupEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _groupRepo.GetById(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _groupRepo.EditAsync(editData);
        }

        public async Task<IEnumerable<Group>> GetAllWithAsync()
        {
            _logger.LogInformation("Get All method is working");

            return await _groupRepo.GetAllWithAsync();
        }

        public async Task<GroupDto> GetByIdAsync(int ? id)
        {
            return _mapper.Map<GroupDto>(await _groupRepo.GetById((int)id));
        }
        public async Task<List<GroupDto>> GetById(List<int> ? id)
        {
            
            var existGroup = await _groupRepo.GetByIdWithAsync22(id);
            var data= _mapper.Map<List<GroupDto>>(existGroup);
            return data;
        }

        
    }
}

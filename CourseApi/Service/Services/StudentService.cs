using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Students;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IMapper mapper,
                           IGroupRepository groupRepo,
                           IStudentRepository studentRepo,
                           ILogger<StudentService> logger)

        {

            _mapper = mapper;
            _groupRepo = groupRepo;
            _studentRepo = studentRepo;
            _logger = logger;
        }
        public async Task CreateAsync(StudentCreateDto model)
        {
            var existGroup = await _groupRepo.GetByIdWithAsync(model.GroupId);
            if (existGroup is null)
            {
                _logger.LogWarning($"Group is not found -{model.GroupId + "-" + DateTime.Now.ToString()}");
                throw new NotFoundException($"id-{model.GroupId} Group not found");
            }
            if (model == null) throw new ArgumentNullException();
            await _studentRepo.CreateAsync(_mapper.Map<Student>(model));
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _studentRepo.GetById(id);
            await _studentRepo.DeleteAsync(data);
        }

        public async Task EditAsync(int id, StudentEditDto model)
        {
            if (model == null) throw new ArgumentNullException();
            var data = await _studentRepo.GetByIdWithAsync(id);

            if (data is null) throw new ArgumentNullException();

            var editData = _mapper.Map(model, data);
            await _studentRepo.EditAsync(editData);
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            return _mapper.Map<StudentDto>(await _studentRepo.GetByIdWithAsync(id));
        }
        public async Task<IEnumerable<StudentDto>> GetAllWithCountryAsync()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _studentRepo.GetAllWithAsync());
        }

        public async Task<IEnumerable<Student>> GetAllWithAsync()
        {
            _logger.LogInformation("Get All method is working");

            return await _studentRepo.GetAllWithAsync();
        }
    }
}

using AutoMapper;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Educations;
using Service.DTOs.Admin.Groups;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepo;
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<EducationService> _logger;


        public EducationService(IEducationRepository educationRepo,
                                IGroupRepository groupRepo,
                                IMapper mapper,
                                ILogger<EducationService> logger
                              )
        {
            _educationRepo = educationRepo;
            _groupRepo = groupRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateAsync(EducationCreateDto data)
        {
            var existCountry = await _groupRepo.GetByIdAsync(data.GroupId);

            if (existCountry is null)
            {
                _logger.LogWarning($"Country not found - {data.GroupId} - {DateTime.Now}");
                throw new NotFoundException("Data Not Found");
            }

            await _educationRepo.CreateAsync(_mapper.Map<Education>(data));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existCountry = await _educationRepo.GetByIdAsync((int)id);

            if (existCountry is null) throw new NullReferenceException();

            await _educationRepo.DeleteAsync(existCountry);
        }

        public async Task EditAsync(int? id, EducationEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var existCountry = await _educationRepo.GetByIdAsync((int)id) ?? throw new NullReferenceException();

            _mapper.Map(model, existCountry);

            await _educationRepo.EditAsync(existCountry);
        }

        public async Task<IEnumerable<EducationDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _educationRepo.GetAllAsync());
        }

        public async Task<EducationDto> GetByIdAsync(int? id)
        {
            return _mapper.Map<EducationDto>(await _educationRepo
                .FindBy(m => m.Id == id, m => m.Group)
                .FirstOrDefaultAsync());
        }
    }
}

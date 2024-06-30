using AutoMapper;
using Domain.Entites;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Groups;
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
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepo,
                              IMapper mapper)
        {
            _groupRepo = groupRepo;
            _mapper = mapper;
        }
        public async Task CreateAsync(GroupCreateDto model)
        {
            if (model is null) throw new ArgumentNullException();
            _groupRepo.CreateAsync(_mapper.Map<Group>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existCountry = await _groupRepo.GetByIdAsync((int)id);

            if (existCountry is null) throw new NullReferenceException();

            await _groupRepo.DeleteAsync(existCountry);
        }

        public async Task EditAsync(int? id, GroupEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var existCountry = await _groupRepo.GetByIdAsync((int)id) ?? throw new NullReferenceException();

            _mapper.Map(model, existCountry);

            await _groupRepo.EditAsync(existCountry);
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(await _groupRepo.GetAllAsync());
        }

        public async Task<GroupDto> GetByIdAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var existCountry = await _groupRepo.GetByIdAsync((int)id);

            if (existCountry is null) throw new NullReferenceException();

            return _mapper.Map<GroupDto>(existCountry);
        }
    }
}

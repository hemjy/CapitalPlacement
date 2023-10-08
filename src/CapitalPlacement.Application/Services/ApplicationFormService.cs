using AutoMapper;
using CapitalPlacement.Application.Common.Models;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Infrastructure.Respository;
using CapitalPlacement.Domain.Services;
namespace CapitalPlacement.Application.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly ICPProgramRepository _repository;
        private readonly IMapper _mapper;
        public ApplicationFormService(ICPProgramRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<ApplicationFormDTO>> GetAsync(Guid programId)
        {
            var program = await _repository.GetByIdAsync(programId);
            if (program == null || program.ApplicationForm == null)
            {
                return Result<ApplicationFormDTO>.Failure("Application Form  not exist");
            }
            var item = _mapper.Map<ApplicationFormDTO>(program.ApplicationForm);
            return Result<ApplicationFormDTO>.Success(item);
        }

        public async Task UpdateAsync(Guid programId, ApplicationFormDTO item)
        {
            var program = await _repository.GetByIdAsync(programId);
            if (program == null )
            {
                throw new ArgumentException("Application Form  not exist");
            }
            var itemToMap = _mapper.Map<ApplicationForm>(item);
            program.ApplicationForm = itemToMap;
            await _repository.UpdateAsync(program);

        }
    }
}

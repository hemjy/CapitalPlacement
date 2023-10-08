using AutoMapper;
using CapitalPlacement.Application.Common.Models;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Infrastructure.Respository;
using CapitalPlacement.Domain.Services;

namespace CapitalPlacement.Application.Services
{
    public class ProgramProcessingService : IProgramProcessingService
    {
        private readonly ICPProgramRepository _repository;
        private readonly IMapper _mapper;
        public ProgramProcessingService(ICPProgramRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task CreateProgramDetailAsync(Guid id, ProgramDetailDTO item, Guid employerId)
        {
            var programDetail = _mapper.Map<ProgramDetail>(item);
            var program = new CPProgram
            {
                id = id.ToString(),
                ProgramDetail = programDetail,
                EmployerId = employerId
            };

            await _repository.CreateAsync(program);
        }


        public async Task<Result<ProgramDetailDTO>> GetProgramDetailsAsync(Guid programId)
        {
            var program = await _repository.GetByIdAsync(programId);
            if (program == null || program.ProgramDetail == null)
            {
                return Result<ProgramDetailDTO>.Failure("Program  not exist");
            }
            var item = _mapper.Map<ProgramDetailDTO>(program.ProgramDetail);
            return Result<ProgramDetailDTO>.Success(item);
        }

        public async Task<Result<ProgramDTO>> Preview(Guid programId)
        {
            var program = await _repository.GetByIdAsync(programId);
            if (program == null)
            {
                return Result<ProgramDTO>.Failure("Program  not exist");
            }
            var item = _mapper.Map<ProgramDTO>(program);
            return Result<ProgramDTO>.Success(item);
        }

        public async Task UpdateProgramDetailAsync(Guid id, ProgramDetailDTO item)
        {
            var program = await _repository.GetByIdAsync(id);
            if (program == null)
            {
                throw new ArgumentException("Program not exist");
            }
            var itemToMap = _mapper.Map<ProgramDetail>(item);
            program.ProgramDetail = itemToMap;
            await _repository.UpdateAsync(program);
        }
    }
}

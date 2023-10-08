using AutoMapper;
using CapitalPlacement.Application.Common.Models;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Infrastructure.Respository;
using CapitalPlacement.Domain.Services;

namespace CapitalPlacement.Application.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly ICPProgramRepository _repository;
        private readonly IMapper _mapper;
        public WorkflowService(ICPProgramRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<WorkflowDTO>> GetAsync(Guid programId)
        {
            var program = await _repository.GetByIdAsync(programId);
            if (program == null || program.Workflow == null)
            {
                return Result<WorkflowDTO>.Failure("Workflow  not exist");
            }
            var item = _mapper.Map<WorkflowDTO>(program.Workflow);
            return Result<WorkflowDTO>.Success(item);
        }

        public async Task UpdateAsync(Guid id, WorkflowDTO item)
        {
            var program = await _repository.GetByIdAsync(id);
            if (program == null)
            {
                throw new ArgumentException("Workflow not exist");
            }
            var itemToMap = _mapper.Map<Workflow>(item);
            program.Workflow = itemToMap;
            await _repository.UpdateAsync(program);

        }
    }
}

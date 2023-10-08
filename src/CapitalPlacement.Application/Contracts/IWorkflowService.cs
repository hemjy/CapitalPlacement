using CapitalPlacement.Application.Common.Models;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;

namespace CapitalPlacement.Domain.Services
{
    public interface IWorkflowService
    {
        Task UpdateAsync(Guid id, WorkflowDTO item);
        Task<Result<WorkflowDTO>> GetAsync(Guid id);
    }
}

using CapitalPlacement.Application.Common.Models;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;

namespace CapitalPlacement.Domain.Services
{
    public interface IProgramProcessingService
    {
        Task UpdateProgramDetailAsync(Guid id, ProgramDetailDTO item);
        Task CreateProgramDetailAsync(Guid id, ProgramDetailDTO item, Guid employerId);
        Task<Result<ProgramDetailDTO>> GetProgramDetailsAsync(Guid programId);
        Task<Result<ProgramDTO>> Preview(Guid id);
    }
}

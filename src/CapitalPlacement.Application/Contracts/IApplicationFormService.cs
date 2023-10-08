using CapitalPlacement.Application.Common.Models;
using CapitalPlacement.Application.DTOs;

namespace CapitalPlacement.Domain.Services
{
    public interface IApplicationFormService
    {
        Task UpdateAsync(Guid programId, ApplicationFormDTO item);
        Task<Result<ApplicationFormDTO>> GetAsync(Guid programId);
    }
}

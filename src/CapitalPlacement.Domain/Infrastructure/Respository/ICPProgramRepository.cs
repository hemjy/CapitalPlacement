using CapitalPlacement.Domain.Entities;

namespace CapitalPlacement.Domain.Infrastructure.Respository
{
    public interface ICPProgramRepository
    {
        Task<CPProgram> GetByIdAsync(Guid id);
        Task<CPProgram> CreateAsync(CPProgram item);
        Task UpdateAsync(CPProgram item);
    }
}

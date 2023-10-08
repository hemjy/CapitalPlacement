using AutoMapper;
using CapitalPlacement.Domain.Entities;

namespace CapitalPlacement.Application.DTOs
{
   
    public class ProgramDTO
    {
        public Guid Id { get; set; }
        public WorkflowDTO Workflow { get; set; }
        public ApplicationFormDTO ApplicationForm { get; set; }
        public ProgramDetailDTO ProgramDetail { get; set; }
    }
}

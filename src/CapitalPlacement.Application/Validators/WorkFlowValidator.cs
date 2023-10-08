using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Enums;
using FluentValidation;

namespace CapitalPlacement.Application.Validators
{
    
    public class WorkflowValidator : AbstractValidator<WorkflowDTO>
    {
        public WorkflowValidator()
        {
            When(x => x.Stages != null && x.Stages.Any(), () =>
            {
                RuleFor(x => x.Stages)
                    .Must(IsValidStageTypeList)
                    .WithMessage("Invalid Stage Type");
            });

        }
        private bool IsValidStageTypeList(List<StageDTO> items)
        {
            foreach (var item in items)
            {
                if (!Enum.TryParse(item.Type.ToString(), true, out StageType _))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

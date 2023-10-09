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
                     .WithMessage("Invalid  Stage Type");
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

    public class StageValidator : AbstractValidator<StageDTO>
    {
        public StageValidator()
        {
            When(x => !string.IsNullOrEmpty(x.Type), () =>
            {
                RuleFor(x => x.Type)
                    .Must(IsValidEnumValue<StageType>)
                    .WithMessage("Invalid Stage Type");
            });

        }
        private bool IsValidEnumValue<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse<T>(value, true, out _))
            {
                return true;
            }
            return false;
        }
    }
}

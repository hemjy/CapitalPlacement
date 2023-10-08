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
                     .Must(IsValidEnumList<StageType, StageDTO>)
                     .WithMessage("Invalid  Stage Type");
            });

        }

        private bool IsValidEnumList<TEnum, TItem>(List<TItem> items) where TEnum : struct, Enum
        {
            foreach (var item in items)
            {
                if (!Enum.TryParse(item.ToString(), out TEnum _))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

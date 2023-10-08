using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Enums;
using FluentValidation;

namespace CapitalPlacement.Application.Validators
{
    
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

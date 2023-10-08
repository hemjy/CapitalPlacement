using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Enums;
using FluentValidation;

namespace CapitalPlacement.Application.Validators
{
    public class ProgramDetailValidator : AbstractValidator<ProgramDetailDTO>
    {
        public ProgramDetailValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Program Title is Required");
            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Program Description is Required");
            RuleFor(x => x.ProgramType).NotNull().NotEmpty().WithMessage("Program Type is Required");
            RuleFor(x => x.ProgramType).Must(IsValidEnumValue<ProgramType>).WithMessage("Invalid Program Type");
            RuleFor(x => x.Location).NotNull().NotEmpty().WithMessage("Program Location is Required");
            RuleFor(x => x.ApplicationOpen).NotNull().GreaterThan(DateTime.MinValue).WithMessage("Application Open is Required");
            RuleFor(x => x.ApplicationClose).NotNull().GreaterThan(DateTime.MinValue).WithMessage("Application Close is Required");

            When(x => !string.IsNullOrEmpty(x.minQualification), () =>
            {
                RuleFor(x => x.minQualification)
                    .Must(IsValidEnumValue<QualificationType>)
                    .WithMessage("Invalid Qualification");
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

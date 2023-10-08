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
            RuleFor(x => x.ProgramType).NotNull().NotEqual(ProgramType.None).WithMessage("Program Type is Required");
            RuleFor(x => x.Location).NotNull().NotEmpty().WithMessage("Program Location is Required");
            RuleFor(x => x.ApplicationOpen).NotNull().GreaterThan(DateTime.MinValue).WithMessage("Application Open is Required");
            RuleFor(x => x.ApplicationClose).NotNull().GreaterThan(DateTime.MinValue).WithMessage("Application Close is Required");
        }
    }
}

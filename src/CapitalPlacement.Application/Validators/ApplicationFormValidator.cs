using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Enums;
using FluentValidation;

namespace CapitalPlacement.Application.Validators
{
    public class ApplicationFormValidator: AbstractValidator<ApplicationFormDTO>
    {
        public ApplicationFormValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email is Required");
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("First Name  is Required");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("Last Name is Required");

            When(x => x.ProfileQuestions != null && x.ProfileQuestions.Any(), () =>
            {
                RuleFor(x => x.ProfileQuestions)
                     .Must(IsValidEnumList<QuestionType, QuestionDTO>)
                     .WithMessage("Invalid  Question Type");
            });

            When(x => x.Educations != null && x.Educations.Any(), () =>
            {
                RuleFor(x => x.Educations)
                     .Must(IsValidEnumList<DegreeType, EducationDTO>)
                     .WithMessage("Invalid Degree Type");
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

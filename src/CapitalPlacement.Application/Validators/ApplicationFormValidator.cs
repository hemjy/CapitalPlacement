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
                     .Must(IsValidQuestionTypeList)
                     .WithMessage("Invalid  Question Type");
            });

            When(x => x.Educations != null && x.Educations.Any(), () =>
            {
                RuleFor(x => x.Educations)
                     .Must(IsValidDegreeTypeList)
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
        private bool IsValidQuestionTypeList(List<QuestionDTO> items)
        {
            foreach (var item in items)
            {
                if (!Enum.TryParse(item.QuestionType.ToString(), true, out QuestionType _))
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsValidDegreeTypeList(List<EducationDTO> items)
        {
            foreach (var item in items)
            {
                if (!Enum.TryParse(item.DegreeType.ToString(),true , out DegreeType _))
                {
                    return false;
                }
            }
            return true;
        }

    }
}

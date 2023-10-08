using AutoMapper;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Application.Mapping
{
    public class ApplicationFormMapper : Profile
    {
        public ApplicationFormMapper()
        {
            CreateMap<ApplicationFormDTO, ApplicationForm>().ReverseMap();
            CreateMap<QuestionDTO, Question>().ReverseMap();
            CreateMap<EducationDTO, Education>().ReverseMap();
            CreateMap<WorkExperienceDTO, WorkExperience>().ReverseMap();
        }
    }
}

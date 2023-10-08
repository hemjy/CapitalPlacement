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
    public class WorkflowMapper : Profile
    {
        public WorkflowMapper()
        {
            CreateMap<WorkflowDTO, Workflow>().ReverseMap();
            CreateMap<StageDTO, Stage>().ReverseMap();
            CreateMap<VideoInterviewQuestionDTO, VideoInterviewQuestion>().ReverseMap();
        }
    }
}

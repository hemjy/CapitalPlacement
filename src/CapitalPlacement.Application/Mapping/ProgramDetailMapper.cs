﻿using AutoMapper;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Application.Mapping
{
    public class ProgramDetailMapper : Profile
    {
        public ProgramDetailMapper()
        {
            CreateMap<ProgramDetailDTO, ProgramDetail>().ReverseMap();
        }

    }
}

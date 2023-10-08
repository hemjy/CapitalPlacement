using Bogus;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Test.Helper
{
    public class DummyDataGenerator
    {
        public static ProgramDetailDTO ProgramDetailDTOValidData()
        {
            var programDetailFaker = new Faker<ProgramDetailDTO>()
           .RuleFor(p => p.Title, f => f.Lorem.Word())
           .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
           .RuleFor(p => p.ProgramType, f => f.PickRandom<ProgramType>().ToString())
           .RuleFor(p => p.ApplicationClose, f => f.Date.Future())
           .RuleFor(p => p.ApplicationOpen, f => f.Date.Future())
           .RuleFor(p => p.Location, f => f.Address.ToString())

           .FinishWith((f, p) => p.Duration = "4 Months");

           return programDetailFaker.Generate();
        }

        public static ProgramDetailDTO ProgramDetailDTOInvalidData()
        {
            var programDetailFaker = new Faker<ProgramDetailDTO>()
           .RuleFor(p => p.Title, f => f.Lorem.Word())
           .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
           .RuleFor(p => p.ProgramType, f => f.PickRandom<ProgramType>().ToString())
           .RuleFor(p => p.ApplicationClose, f => f.PickRandom<DateTime>())
           .RuleFor(p => p.Location, f => f.Address.ToString())

           .FinishWith((f, p) => p.Duration = "4 Months");

            return programDetailFaker.Generate();
        }
    }
}

using AutoMapper;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Enums;

namespace CapitalPlacement.Application.DTOs
{
   
    public class ProgramDetailDTO
    {
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string Description { get; set; }
        public string? Benefits { get; set; }
        public List<string>? Skills { get; set; }
        public string? ApplicationCriteria { get; set; }
        public string ProgramType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public string? Duration { get; set; }
        public string? Location { get; set; }
        public bool IsRemote { get; set; }
        public string? minQualification { get; set; }
        public int MaxNoOfApplication { get; set; }


    }
}

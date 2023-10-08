using AutoMapper;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Enums;

namespace CapitalPlacement.Application.DTOs
{

    public class WorkflowDTO
    {
        public List<StageDTO> Stages { get; set; }
    }

    public class StageDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public List<VideoInterviewQuestionDTO> VideoInterviewQuestions { get; set; }
    }

    public class VideoInterviewQuestionDTO
    {
        public string Text { get; set; }
        public int maxDuration { get; set; }
        public DateTime deadline { get; set; }
    }

   
}

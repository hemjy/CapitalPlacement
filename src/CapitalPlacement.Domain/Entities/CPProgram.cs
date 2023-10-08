using CapitalPlacement.Domain.Enums;
using System.Text.Json.Serialization;

namespace CapitalPlacement.Domain.Entities
{
    public class CPProgram
    {
        
        public string id { get; set; }
        public Workflow Workflow { get; set; }
        public ApplicationForm ApplicationForm { get; set; }
        public ProgramDetail ProgramDetail { get; set; }
        public Guid EmployerId { get; set; }
    }

    public class ApplicationForm
    {

        public string CoverImageUrl { get; set; }
        public string firstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string phonenumber { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDnumber { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public List<Question> personalInfoQuestions { get; set; }
        public List<Education> Educations { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public string ResumeUrl { get; set; }
        public string EssaySelf { get; set; }
        public int graduationYear { get; set; }
        public List<Question> ProfileQuestions { get; set; }
    }


    public class Question
    {
        public string Text { get; set; }
        public string QuestionType { get; set; }
    }

    public class Education
    {
        public string SchoolName { get; set; }
        public string CourseName { get; set; }
        public string DegreeType { get; set; }
        public string StudyLocation { get; set; }
        public DateTime startDate { get; set; }
        public DateTime enddate { get; set; }
        public bool IsCurrentlyStudy { get; set; }
    }

    public class WorkExperience
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string WorkLocation { get; set; }
        public DateTime startDate { get; set; }
        public DateTime enddate { get; set; }
        public bool IsCurrentlyWorking { get; set; }
    }

    public class Workflow
    {
        public List<Stage> Stages { get; set; }
    }

    public class Stage
    {
        public string Name { get; set; }
        public string StageType { get; set; }
        public string Text { get; set; }
        public List<VideoInterviewQuestion> VideoInterviewQuestions { get; set; }
    }

    public class VideoInterviewQuestion
    {
        public string Text { get; set; }
        public int maxDuration { get; set; }
        public DateTime deadline { get; set; }
    }

    public class ProgramDetail
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Benefits { get; set; }
        public List<string> Skills { get; set; }
        public string ApplicationCriteria { get; set; }
        public string ProgramType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public string Duration { get; set; }
        public string Location { get; set; }
        public bool IsRemote { get; set; }
        public string minQualification { get; set; }
        public int MaxNoOfApplication { get; set; }


    }
}

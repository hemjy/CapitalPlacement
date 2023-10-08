using AutoMapper;
using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Enums;

namespace CapitalPlacement.Application.DTOs
{

    public class ApplicationFormDTO
    {
        public string CoverImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public List<QuestionDTO> PersonalInfoQuestions { get; set; }
        public List<EducationDTO> Educations { get; set; }
        public List<WorkExperienceDTO> WorkExperiences { get; set; }
        public string ResumeUrl { get; set; }
        public string EssaySelf { get; set; }
        public int GraduationYear { get; set; } 
        public List<QuestionDTO> ProfileQuestions { get; set; }
    }

    public class QuestionDTO
    {
        public string Text { get; set; }
        public string QuestionType { get; set; }
    }

    public class EducationDTO
    {
        public string SchoolName { get; set; }
        public string CourseName { get; set; }
        public string DegreeType { get; set; }
        public string StudyLocation { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public bool IsCurrentlyStudy { get; set; }
    }

    public class WorkExperienceDTO
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string WorkLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrentlyWorking { get; set; }
    }
}

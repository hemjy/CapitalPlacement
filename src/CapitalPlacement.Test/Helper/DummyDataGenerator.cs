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
        public static WorkflowDTO GenerateFakeWorkflow()
        {
            var fake = new Faker<WorkflowDTO>()
                .RuleFor(w => w.Stages, f => GenerateFakeStages(3)); 

            return fake.Generate();
        }
        public static WorkflowDTO GenerateInvalidFakeWorkflow()
        {
            var fake = new Faker<WorkflowDTO>()
                .RuleFor(w => w.Stages, f => GenerateInvalidFakeStages(3));

            return fake.Generate();
        }
        private static List<StageDTO> GenerateFakeStages(int count)
        {
            var fake = new Faker<StageDTO>()
                .RuleFor(s => s.Name, f => f.Random.Word())
                .RuleFor(s => s.Type, f => f.PickRandom<StageType>().ToString())
                .RuleFor(s => s.Text, f => f.Lorem.Sentence())
                .RuleFor(s => s.VideoInterviewQuestions, f => GenerateFakeVideoInterviewQuestions(2)); // Generate 2 fake questions per stage

            return fake.Generate(count);
        }
        private static List<StageDTO> GenerateInvalidFakeStages(int count)
        {
            var fake = new Faker<StageDTO>()
                .RuleFor(s => s.Name, f => f.Random.Word())
                .RuleFor(s => s.Type, f => f.PickRandom("rete", "rte"))
                .RuleFor(s => s.Text, f => f.Lorem.Sentence())
                .RuleFor(s => s.VideoInterviewQuestions, f => GenerateFakeVideoInterviewQuestions(2)); // Generate 2 fake questions per stage

            return fake.Generate(count);
        }
        private static List<VideoInterviewQuestionDTO> GenerateFakeVideoInterviewQuestions(int count)
        {
            var fake = new Faker<VideoInterviewQuestionDTO>()
                .RuleFor(q => q.Text, f => f.Lorem.Sentence())
                .RuleFor(q => q.maxDuration, f => f.Random.Int(30, 180)) // Generate a random duration between 30 and 180 seconds
                .RuleFor(q => q.deadline, f => f.Date.Future()); // Generate a future date as a deadline

            return fake.Generate(count);
        }
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
          .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
          .RuleFor(p => p.ProgramType, f => f.PickRandom<ProgramType>().ToString())
          .RuleFor(p => p.ApplicationClose, f => f.Date.Future())
          .RuleFor(p => p.ApplicationOpen, f => f.Date.Future())
          .RuleFor(p => p.Location, f => f.Address.ToString())

          .FinishWith((f, p) => p.Duration = "4 Months");

            return programDetailFaker.Generate();

            return programDetailFaker.Generate();
        }

        public static ApplicationFormDTO GenerateFakeApplicationForm()
        {
            var fake = new Faker<ApplicationFormDTO>()
                .RuleFor(a => a.CoverImageUrl, f => f.Image.PlaceImgUrl())
                .RuleFor(a => a.FirstName, f => f.Person.FirstName)
                .RuleFor(a => a.LastName, f => f.Person.LastName)
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.PhoneNumber, f => f.Person.Phone)
                .RuleFor(a => a.Nationality, f => f.Address.Country())
                .RuleFor(a => a.CurrentResidence, f => f.Address.City())
                .RuleFor(a => a.IDNumber, f => f.Random.AlphaNumeric(10))
                .RuleFor(a => a.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(a => a.Gender, f => f.PickRandom("Male", "Female", "Other"))
                .RuleFor(a => a.PersonalInfoQuestions, f => GenerateFakeQuestions(3))
                .RuleFor(a => a.Educations, f => GenerateFakeEducations(2))
                .RuleFor(a => a.WorkExperiences, f => GenerateFakeWorkExperiences(2))
                .RuleFor(a => a.ResumeUrl, f => f.Internet.Url())
                .RuleFor(a => a.EssaySelf, f => f.Lorem.Paragraph())
                .RuleFor(a => a.GraduationYear, f => f.Random.Int(2000, 2023))
                .RuleFor(a => a.ProfileQuestions, f => GenerateFakeQuestions(2));

            return fake.Generate();
        }

        public static ApplicationFormDTO GenerateInvalidFakeApplicationForm()
        {
            var fake = new Faker<ApplicationFormDTO>()
                .RuleFor(a => a.CoverImageUrl, f => f.Image.PlaceImgUrl())
                .RuleFor(a => a.FirstName, f => f.Person.FirstName)
                .RuleFor(a => a.LastName, f => f.Person.LastName)
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.PhoneNumber, f => f.Person.Phone)
                .RuleFor(a => a.Nationality, f => f.Address.Country())
                .RuleFor(a => a.CurrentResidence, f => f.Address.City())
                .RuleFor(a => a.IDNumber, f => f.Random.AlphaNumeric(10))
                .RuleFor(a => a.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(a => a.Gender, f => f.PickRandom("Male", "Female", "Other"))
                .RuleFor(a => a.PersonalInfoQuestions, f => GenerateInavlidFakeQuestions(3))
                .RuleFor(a => a.Educations, f => GenerateFakeEducations(2))
                .RuleFor(a => a.WorkExperiences, f => GenerateFakeWorkExperiences(2))
                .RuleFor(a => a.ResumeUrl, f => f.Internet.Url())
                .RuleFor(a => a.EssaySelf, f => f.Lorem.Paragraph())
                .RuleFor(a => a.GraduationYear, f => f.Random.Int(2000, 2023))
                .RuleFor(a => a.ProfileQuestions, f => GenerateFakeQuestions(2));

            return fake.Generate();
        }

        public static List<QuestionDTO> GenerateFakeQuestions(int count)
        {
            var fake = new Faker<QuestionDTO>()
                .RuleFor(q => q.Text, f => f.Lorem.Sentence())
                .RuleFor(q => q.QuestionType, f => f.PickRandom<QuestionType>().ToString());

            return fake.Generate(count);
        }

        public static List<QuestionDTO> GenerateInavlidFakeQuestions(int count)
        {
            var fake = new Faker<QuestionDTO>()
                .RuleFor(q => q.Text, f => f.Lorem.Sentence())
                .RuleFor(q => q.QuestionType, f => f.PickRandom("MultipleChoices", "OPen"));

            return fake.Generate(count);
        }

        private static List<EducationDTO> GenerateFakeEducations(int count)
        {
            var fake = new Faker<EducationDTO>()
                .RuleFor(e => e.SchoolName, f => f.Company.CompanyName())
                .RuleFor(e => e.CourseName, f => f.Random.Words(3))
                .RuleFor(e => e.DegreeType, f => f.PickRandom<DegreeType>().ToString())
                .RuleFor(e => e.StudyLocation, f => f.Address.City())
                .RuleFor(e => e.StartDate, f => f.Date.Past())
                .RuleFor(e => e.EndDate, f => f.Date.Past())
                .RuleFor(e => e.IsCurrentlyStudy, f => f.Random.Bool());

            return fake.Generate(count);
        }

        private static List<WorkExperienceDTO> GenerateFakeWorkExperiences(int count)
        {
            var fake = new Faker<WorkExperienceDTO>()
                .RuleFor(w => w.CompanyName, f => f.Company.CompanyName())
                .RuleFor(w => w.Position, f => f.Name.JobTitle())
                .RuleFor(w => w.WorkLocation, f => f.Address.City())
                .RuleFor(w => w.StartDate, f => f.Date.Past())
                .RuleFor(w => w.EndDate, f => f.Date.Past())
                .RuleFor(w => w.IsCurrentlyWorking, f => f.Random.Bool());

            return fake.Generate(count);
        }
    }
}

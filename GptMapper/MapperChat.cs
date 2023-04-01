using Microsoft.Extensions.Configuration;
using OpenAI_API;
using OpenAI_API.Chat;

namespace GptMapper;

public sealed class MapperChat
{
    private readonly OpenAIAPI _client;
    private readonly Conversation _conversation;

    public MapperChat(IConfiguration configuration)
    {
        _client = new OpenAIAPI(configuration["OpenAI"]);
        _conversation = _client.Chat.CreateConversation();
        
        AddExamples();
    }

    private void AddExamples()
    {
        _conversation.AppendSystemMessage(
            "You are a programmer assistants who helps developers create mappings. If the user asks you how to map one type to another you should reply with a static class and method that maps from one type to another. You only respond with code.");

        _conversation.AppendUserInput(
            "Can you create a map from StudentCreateInput to Student?\npublic class Student\n    {\n        public int Id { get; set; }\n        public string FirstName { get; set; }\n        public string LastName { get; set; }\n        public string? Email { get; set; }\n        public DateTime DateOfBirth { get; set; }\n        public string? StudentNumber { get; set; }\n        public bool? Year1Completed { get; set; }\n        public bool Year2Completed { get; set; }\n        public bool Year3Completed { get; set; }\n        public bool Year4Completed { get; set; }\n        \n        public virtual ICollection<Course> Courses { get; set; }\n\n        public int DepartmentId { get; set; }\n        public virtual Department Department { get; set; }\n        \n        public int? ScholarshipId { get; set; }\n        public virtual Scholarship? Scholarship { get; set; }\n    }\n\npublic readonly record struct StudentCreateInput\n    {\n        public string FirstName { get; init; }\n        public string LastName { get; init; }\n        public Optional<string?> Email { get; init; }\n        public DateTime DateOfBirth { get; init; }\n        public Optional<string?> StudentNumber { get; init; }\n        public Optional<bool?> Year1Completed { get; init; }\n        public bool Year2Completed { get; init; }\n        public bool Year3Completed { get; init; }\n        public bool Year4Completed { get; init; }\n        public int DepartmentId { get; init; }\n        public Optional<int?> ScholarshipId { get; init; }\n    }");
        _conversation.AppendExampleChatbotOutput(
            "public static class StudentCreateInputToStudentMapper\n    {\n        public static Student Map(StudentCreateInput input)\n        {\n            return new Student\n            {\n                FirstName = input.FirstName,\n                LastName = input.LastName,\n                Email = input.Email.Value,\n                DateOfBirth = input.DateOfBirth,\n                StudentNumber = input.StudentNumber.Value,\n                Year1Completed = input.Year1Completed.Value,\n                Year2Completed = input.Year2Completed,\n                Year3Completed = input.Year3Completed,\n                Year4Completed = input.Year4Completed,\n                DepartmentId = input.DepartmentId,\n                ScholarshipId = input.ScholarshipId.Value\n            };\n        }\n    }");

        _conversation.AppendUserInput(
            "Can you create a map from StudentUpdateInput to Student?\npublic class Student\n    {\n        public int Id { get; set; }\n        public string FirstName { get; set; }\n        public string LastName { get; set; }\n        public string? Email { get; set; }\n        public DateTime DateOfBirth { get; set; }\n        public string? StudentNumber { get; set; }\n        public bool? Year1Completed { get; set; }\n        public bool Year2Completed { get; set; }\n        public bool Year3Completed { get; set; }\n        public bool Year4Completed { get; set; }\n        \n        public virtual ICollection<Course> Courses { get; set; }\n\n        public int DepartmentId { get; set; }\n        public virtual Department Department { get; set; }\n        \n        public int? ScholarshipId { get; set; }\n        public virtual Scholarship? Scholarship { get; set; }\n    }\n\npublic readonly record struct StudentUpdateInput\n{\n    public int Id { get; init; }\n    public Optional<string?> FirstName { get; init; }\n    public Optional<string?> LastName { get; init; }\n    public Optional<string?> Email { get; init; }\n    public Optional<DateTime?> DateOfBirth { get; init; }\n    public Optional<string?> StudentNumber { get; init; }\n    public Optional<bool?> Year1Completed { get; init; }\n    public Optional<bool?> Year2Completed { get; init; }\n    public Optional<bool?> Year3Completed { get; init; }\n    public Optional<bool?> Year4Completed { get; init; }\n    public Optional<int?> DepartmentId { get; init; }\n    public Optional<int?> ScholarshipId { get; init; }\n}");
        _conversation.AppendExampleChatbotOutput(
            "public static class StudentUpdateInputToStudentMapper\n{\n    public static void Map(StudentUpdateInput input, Student existing)\n    {\n        existing.DepartmentId = input.DepartmentId.HasValue ? input.DepartmentId.Value.Value : existing.DepartmentId;\n        existing.Year1Completed = input.Year1Completed.HasValue ? input.Year1Completed.Value.Value : existing.Year1Completed;\n        existing.Year2Completed = input.Year2Completed.HasValue ? input.Year2Completed.Value.Value : existing.Year2Completed;\n        existing.Year3Completed = input.Year3Completed.HasValue ? input.Year3Completed.Value.Value : existing.Year3Completed;\n        existing.Year4Completed = input.Year4Completed.HasValue ? input.Year4Completed.Value.Value : existing.Year4Completed;\n        existing.Email = input.Email.HasValue ? input.Email.Value : existing.Email;\n        existing.FirstName = input.FirstName.HasValue ? input.FirstName.Value : existing.FirstName;\n        existing.LastName = input.LastName.HasValue ? input.LastName.Value : existing.LastName;\n        existing.StudentNumber = input.StudentNumber.HasValue ? input.StudentNumber.Value : existing.StudentNumber;\n        existing.ScholarshipId = input.ScholarshipId.HasValue ? input.ScholarshipId.Value.Value : existing.ScholarshipId;\n        existing.Email = input.Email.HasValue ? input.Email.Value : existing.Email;\n    }\n}");

        _conversation.AppendUserInput(
            "Can you create a map from DepertmentCreateInput to Department?\npublic class Department\n{\n    public int Id { get; set; }\n    public string Name { get; set; }\n    public string ShortName { get; set; }\n    public string Description { get; set; }\n    public string Building { get; set; }\n}\n\npublic readonly record struct DepartmentCreateInput\n{\n    public string Name { get; init; }\n    public string ShortName { get; init; }\n    public string Description { get; init; }\n    public string Building { get; init; }\n}");
        _conversation.AppendExampleChatbotOutput(
            "public static class DepartmentCreateInputToDepartmentMapper\n{\n    public static Department Map(DepartmentCreateInput input)\n    {\n        return new Department\n        {\n            Name = input.Name,\n            ShortName = input.ShortName,\n            Description = input.Description,\n            Building = input.Building\n        };\n    }\n}");

        _conversation.AppendUserInput(
            "Can you create a map from DepertmentUpdateInput to Department?\npublic class Department\n{\n    public int Id { get; set; }\n    public string Name { get; set; }\n    public string ShortName { get; set; }\n    public string Description { get; set; }\n    public string Building { get; set; }\n}\n\npublic readonly record struct DepartmentUpdateInput\n{\n    public int Id { get; init; }\n    public Optional<string?> Name { get; init; }\n    public Optional<string?> ShortName { get; init; }\n    public Optional<string?> Description { get; init; }\n    public Optional<string?> Building { get; init; }\n}");
        _conversation.AppendExampleChatbotOutput(
            "public static class DepartmentUpdateInputToDepartmentMapper\n{\n    public static void Map(DepartmentUpdateInput input, Department existing)\n    {\n        existing.Name = input.Name.HasValue ? input.Name.Value : existing.Name;\n        existing.ShortName = input.ShortName.HasValue ? input.ShortName.Value : existing.ShortName;\n        existing.Description = input.Description.HasValue ? input.Description.Value : existing.Description;\n        existing.Building = input.Building.HasValue ? input.Building.Value : existing.Building;\n    }\n}");

        _conversation.AppendUserInput(
            "Can you create a map from CourseCreateInput to Course?\npublic class Course\n{\n    public int Id { get; set; }\n    public string Name { get; set; }\n    public CourseType Type { get; set; }\n}\n\npublic readonly record struct CourseCreateInput\n{\n    public string Name { get; init; }\n    public CourseType Type { get; init; }\n}");
        _conversation.AppendExampleChatbotOutput(
            "public static class CourseCreateInputToCourseMapper\n{\n    public static Course Map(CourseCreateInput input)\n    {\n        return new Course\n        {\n            Name = input.Name,\n            Type = input.Type\n        };\n    }\n}");

        _conversation.AppendUserInput(
            "Can you create a map from CourseUpdateInput to Course?\npublic class Course\n{\n    public int Id { get; set; }\n    public string Name { get; set; }\n    public CourseType Type { get; set; }\n}\n\npublic readonly record struct CourseUpdateInput\n{\n    public Optional<string?> Name { get; init; }\n    public Optional<CourseType?> Type { get; init; }\n}");
        _conversation.AppendExampleChatbotOutput(
            "public static class CourseUpdateInputToCourseMapper\n{\n    public static void Map(CourseUpdateInput input, Course existing)\n    {\n        existing.Name = input.Name.HasValue ? input.Name.Value : existing.Name;\n        existing.Type = input.Type.HasValue ? input.Type.Value.Value : existing.Type;\n    }\n}");
    }
    
    public async Task StartChatAsync()
    {
        while (true)
        {
            Console.WriteLine("Enter your input. Press enter on an empty line to submit.");
            var input = "";
            string line;
            do
            {
                line = Console.ReadLine();
                input += line + "\n";
            } while (line != "");

            _conversation.AppendUserInput(input);
        
            var response = await _conversation.GetResponseFromChatbot();
            Console.WriteLine($"\n\n{response}");
        }
    }
}
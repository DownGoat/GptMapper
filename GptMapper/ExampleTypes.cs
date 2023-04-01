using HotChocolate;
using Records;
using Targets;

namespace Targets
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? StudentNumber { get; set; }
        public bool? Year1Completed { get; set; }
        public bool Year2Completed { get; set; }
        public bool Year3Completed { get; set; }
        public bool Year4Completed { get; set; }
        
        public virtual ICollection<Course> Courses { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        
        public int? ScholarshipId { get; set; }
        public virtual Scholarship? Scholarship { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Building { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourseType Type { get; set; }
    }
    
    public class Scholarship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public enum CourseType
    {
        Undergraduate,
        Postgraduate
    }
}


namespace Records
{
    public readonly record struct StudentUpdateInput
    {
        public int Id { get; init; }
        public Optional<string?> FirstName { get; init; }
        public Optional<string?> LastName { get; init; }
        public Optional<string?> Email { get; init; }
        public Optional<DateTime?> DateOfBirth { get; init; }
        public Optional<string?> StudentNumber { get; init; }
        public Optional<bool?> Year1Completed { get; init; }
        public Optional<bool?> Year2Completed { get; init; }
        public Optional<bool?> Year3Completed { get; init; }
        public Optional<bool?> Year4Completed { get; init; }
        public Optional<int?> DepartmentId { get; init; }
        public Optional<int?> ScholarshipId { get; init; }
    }
    
    public readonly record struct StudentCreateInput
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Optional<string?> Email { get; init; }
        public DateTime DateOfBirth { get; init; }
        public Optional<string?> StudentNumber { get; init; }
        public Optional<bool?> Year1Completed { get; init; }
        public bool Year2Completed { get; init; }
        public bool Year3Completed { get; init; }
        public bool Year4Completed { get; init; }
        public int DepartmentId { get; init; }
        public Optional<int?> ScholarshipId { get; init; }
    }
    
    public readonly record struct DepartmentCreateInput
    {
        public string Name { get; init; }
        public string ShortName { get; init; }
        public string Description { get; init; }
        public string Building { get; init; }
    }
    
    public readonly record struct DepartmentUpdateInput
    {
        public int Id { get; init; }
        public Optional<string?> Name { get; init; }
        public Optional<string?> ShortName { get; init; }
        public Optional<string?> Description { get; init; }
        public Optional<string?> Building { get; init; }
    }
    
    public readonly record struct CourseCreateInput
    {
        public string Name { get; init; }
        public CourseType Type { get; init; }
    }
    
    public readonly record struct CourseUpdateInput
    {
        public Optional<string?> Name { get; init; }
        public Optional<CourseType?> Type { get; init; }
    }
    
    public readonly record struct ScholarshipCreateInput
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
    
    public readonly record struct ScholarshipUpdateInput
    {
        public int Id { get; init; }
        public Optional<string?> Name { get; init; }
        public Optional<string?> Description { get; init; }
    }

}

namespace RecordsOutput
{
    public static class StudentCreateInputToStudentMapper
    {
        public static Student Map(StudentCreateInput input)
        {
            return new Student
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email.Value,
                DateOfBirth = input.DateOfBirth,
                StudentNumber = input.StudentNumber.Value,
                Year1Completed = input.Year1Completed.Value,
                Year2Completed = input.Year2Completed,
                Year3Completed = input.Year3Completed,
                Year4Completed = input.Year4Completed,
                DepartmentId = input.DepartmentId,
                ScholarshipId = input.ScholarshipId.Value
            };
        }
    }

    public static class StudentUpdateInputToStudentMapper
    {
        public static void Map(StudentUpdateInput input, Student existing)
        {
            existing.DepartmentId = input.DepartmentId.HasValue ? input.DepartmentId.Value.Value : existing.DepartmentId;
            existing.Year1Completed = input.Year1Completed.HasValue ? input.Year1Completed.Value.Value : existing.Year1Completed;
            existing.Year2Completed = input.Year2Completed.HasValue ? input.Year2Completed.Value.Value : existing.Year2Completed;
            existing.Year3Completed = input.Year3Completed.HasValue ? input.Year3Completed.Value.Value : existing.Year3Completed;
            existing.Year4Completed = input.Year4Completed.HasValue ? input.Year4Completed.Value.Value : existing.Year4Completed;
            existing.Email = input.Email.HasValue ? input.Email.Value : existing.Email;
            existing.FirstName = input.FirstName.HasValue ? input.FirstName.Value : existing.FirstName;
            existing.LastName = input.LastName.HasValue ? input.LastName.Value : existing.LastName;
            existing.StudentNumber = input.StudentNumber.HasValue ? input.StudentNumber.Value : existing.StudentNumber;
            existing.ScholarshipId = input.ScholarshipId.HasValue ? input.ScholarshipId.Value.Value : existing.ScholarshipId;
            existing.Email = input.Email.HasValue ? input.Email.Value : existing.Email;
        }
    }
    
    public static class DepartmentCreateInputToDepartmentMapper
    {
        public static Department Map(DepartmentCreateInput input)
        {
            return new Department
            {
                Name = input.Name,
                ShortName = input.ShortName,
                Description = input.Description,
                Building = input.Building
            };
        }
    }
    
    public static class DepartmentUpdateInputToDepartmentMapper
    {
        public static void Map(DepartmentUpdateInput input, Department existing)
        {
            existing.Name = input.Name.HasValue ? input.Name.Value : existing.Name;
            existing.ShortName = input.ShortName.HasValue ? input.ShortName.Value : existing.ShortName;
            existing.Description = input.Description.HasValue ? input.Description.Value : existing.Description;
            existing.Building = input.Building.HasValue ? input.Building.Value : existing.Building;
        }
    }
    
    public static class CourseCreateInputToCourseMapper
    {
        public static Course Map(CourseCreateInput input)
        {
            return new Course
            {
                Name = input.Name,
                Type = input.Type
            };
        }
    }
    
    public static class CourseUpdateInputToCourseMapper
    {
        public static void Map(CourseUpdateInput input, Course existing)
        {
            existing.Name = input.Name.HasValue ? input.Name.Value : existing.Name;
            existing.Type = input.Type.HasValue ? input.Type.Value.Value : existing.Type;
        }
    }
}
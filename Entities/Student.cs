namespace School.Api.Entities;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public required string Course { get; set; }
    public required string Address { get; set; }

}

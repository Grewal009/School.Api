using System.ComponentModel.DataAnnotations;

namespace School.Api.Entities;

public class Student
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required]
    public DateOnly DateOfBirth { get; set; }
    [Required]
    [StringLength(50)]
    public required string Course { get; set; }
    [Required]
    [StringLength(100)]
    public required string Address { get; set; }

}

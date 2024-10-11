using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    [Required]
    [StringLength(50)]
    public required string Course { get; set; }
    [Required]
    [StringLength(100)]
    public required string Address { get; set; }

    //navigation property
    public ICollection<Preference>? Preferences { get; set; }

}

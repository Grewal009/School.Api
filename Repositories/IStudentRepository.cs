using School.Api.Entities;

namespace School.Api.Repositories;

public interface IStudentRepository
{
    Task CreateAsync(Student student);
    Task DeleteAsync(int id);
    Task<Student?> GetByIDAsync(int id);
    Task<IEnumerable<Student>> GetALLAsync();
    Task UpdateAsync(Student updatedStudent);
}

using School.Api.Entities;

namespace School.Api.Repositories;

public interface IStudentRepository
{
    void Create(Student student);
    void Delete(int id);
    Student? GetByID(int id);
    IEnumerable<Student> GetALL();
    void Update(Student updatedStudent);
}

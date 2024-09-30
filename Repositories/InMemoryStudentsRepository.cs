using School.Api.Entities;

namespace School.Api.Repositories;
public class InMemoryStudentsRepository : IStudentRepository
{
    List<Student> students = new List<Student>(){
    new Student(){Id=1,Name="Per",DateOfBirth=new DateOnly(1995,10,15),Course="Web Development",Address="0500 Oslo"},
    new Student(){Id=2,Name="Peter",DateOfBirth=new DateOnly(1996,1,1),Course="Frontend Development",Address="0520 Oslo"},
    new Student(){Id=3,Name="Pål",DateOfBirth=new DateOnly(1997,8,25),Course="Web Development",Address="0506 Oslo"},
    };

    //method to return all students
    public async Task<IEnumerable<Student>> GetALLAsync()
    {
        return await Task.FromResult(students);
    }

    //method to return student by id
    public async Task<Student?> GetByIDAsync(int id)
    {
        return await Task.FromResult(students.Find(s => s.Id == id));
    }

    //method to create a new student
    public async Task CreateAsync(Student student)
    {
        student.Id = students.Max(s => s.Id) + 1;
        students.Add(student);

        await Task.CompletedTask;
    }

    //method to update a student
    public async Task UpdateAsync(Student updatedStudent)
    {
        var index = students.FindIndex(s => s.Id == updatedStudent.Id);
        students[index] = updatedStudent;

        await Task.CompletedTask;
    }

    //method to delete a student
    public async Task DeleteAsync(int id)
    {
        var index = students.FindIndex((s) => s.Id == id);
        students.RemoveAt(index);

        await Task.CompletedTask;
    }


}
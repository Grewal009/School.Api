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
    public IEnumerable<Student> GetALL()
    {
        return students;
    }

    //method to return student by id
    public Student? GetByID(int id)
    {
        return students.Find(s => s.Id == id);
    }

    //method to create a new student
    public void Create(Student student)
    {
        student.Id = students.Max(s => s.Id) + 1;
        students.Add(student);
    }

    //method to update a student
    public void Update(Student updatedStudent)
    {
        var index = students.FindIndex(s => s.Id == updatedStudent.Id);
        students[index] = updatedStudent;
    }

    //method to delete a student
    public void Delete(int id)
    {
        var index = students.FindIndex((s) => s.Id == id);
        students.RemoveAt(index);
    }


}
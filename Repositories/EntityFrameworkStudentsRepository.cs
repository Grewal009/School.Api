using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Api.Data;
using School.Api.Entities;

namespace School.Api.Repositories
{
    public class EntityFrameworkStudentsRepository : IStudentRepository
    {
        private SchoolContext schoolContext;

        public EntityFrameworkStudentsRepository(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }




        public IEnumerable<Student> GetALL()
        {
            return schoolContext.Students.AsNoTracking().ToList();
        }

        public Student? GetByID(int id)
        {
            return schoolContext.Students.Find(id);
        }

        public void Create(Student student)
        {
            schoolContext.Students.Add(student);
            schoolContext.SaveChanges();
        }

        public void Update(Student updatedStudent)
        {
            schoolContext.Update(updatedStudent);
            schoolContext.SaveChanges();
        }

        public void Delete(int id)
        {
            schoolContext.Students.Where(s => s.Id == id).ExecuteDelete();
        }
    }
}
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




        public async Task<IEnumerable<Student>> GetALLAsync()
        {
            return await schoolContext.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student?> GetByIDAsync(int id)
        {
            return await schoolContext.Students.FindAsync(id);
        }

        public async Task CreateAsync(Student student)
        {
            schoolContext.Students.Add(student);
            await schoolContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student updatedStudent)
        {
            schoolContext.Update(updatedStudent);
            await schoolContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await schoolContext.Students.Where(s => s.Id == id).ExecuteDeleteAsync();
        }
    }
}
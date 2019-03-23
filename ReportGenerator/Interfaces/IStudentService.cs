using ReportGenerator.Models;
using System.Collections.Generic;

namespace ReportGenerator.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAll();

        List<Student> GetByCourse(int courseNumber);

        Student GetById(int id);

        Student Create(Student student);

        Student Update(Student student);

        bool Delete(int id);

        void DeleteAll();
    }
}

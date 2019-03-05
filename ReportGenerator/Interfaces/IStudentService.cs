using ReportGenerator.Models;
using System.Collections.Generic;

namespace ReportGenerator.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetAll();

        Student GetById(int id);

        Student Create(Student student);

        Student Update(Student student);

        bool Delete(int id);
    }
}

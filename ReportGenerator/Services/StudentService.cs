using ReportGenerator.Data;
using ReportGenerator.Interfaces;
using ReportGenerator.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReportGenerator.Services
{
    public class StudentService : IStudentService
    {

        private ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Where(s => s.Id == id).FirstOrDefault();
        }

        public Student Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student Update(Student student)
        {
            var studentToUpdate = GetById(student.Id);
            if (studentToUpdate != null)
            {
                if (!string.IsNullOrWhiteSpace(student.FirstName))
                {
                    studentToUpdate.FirstName = student.FirstName;
                }
                if (!string.IsNullOrWhiteSpace(student.LastName))
                {
                    studentToUpdate.LastName = student.LastName;
                }
                if (!string.IsNullOrWhiteSpace(student.FatherName))
                {
                    studentToUpdate.FatherName = student.FatherName;
                }
                if (student.EnterDate != null)
                {
                    studentToUpdate.EnterDate = student.EnterDate;
                }
            }
            _context.Students.Update(student);
            _context.SaveChanges();
            return student;
        }

        public bool Delete(int id)
        {
            var studentToDelete = GetById(id);
            if (studentToDelete == null)
            {
                return false;
            }

            _context.Students.Remove(studentToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}

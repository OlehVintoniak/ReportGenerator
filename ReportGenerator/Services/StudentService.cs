using Microsoft.EntityFrameworkCore;
using ReportGenerator.Data;
using ReportGenerator.Interfaces;
using ReportGenerator.Models;
using System.Collections.Generic;
using System.Linq;

namespace ReportGenerator.Services {
  public class StudentService : IStudentService {

    private ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context) {
      _context = context;
    }

    public List<Student> GetAll() {
      return _context.Students.ToList();
    }

    public Student GetById(int id) {
      return _context.Students.Where(s => s.Id == id).FirstOrDefault();
    }

    public Student Create(Student student) {
      _context.Students.Add(student);
      _context.SaveChanges();
      return student;
    }

    public Student Update(Student student) {
      _context.Entry(student).State = EntityState.Modified;
      _context.SaveChanges();
      return student;
    }

    public bool Delete(int id) {
      var studentToDelete = GetById(id);
      if (studentToDelete == null) {
        return false;
      }

      _context.Students.Remove(studentToDelete);
      _context.SaveChanges();
      return true;
    }

    public void DeleteAll() {
      _context.Students.RemoveRange(_context.Students);
      _context.SaveChanges();
    }

    public List<Student> GetByCourse(int courseNumber) {
      return _context.Students
          .Where(s => s.Course == courseNumber)
          .ToList();
    }
  }
}

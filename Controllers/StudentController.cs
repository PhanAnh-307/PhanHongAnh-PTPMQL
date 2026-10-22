using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;
using DemoMVC.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace DemoMVC.Controllers;
public class StudentController: Controller {
    private readonly ApplicationDbContext _context;

    public StudentController(ApplicationDbContext context) {
        _context = context;
    }
    public IActionResult Index(){
        var students = _context.Students
                                .Include(s => s.Faculty)
                                .ToList();

        return View(students);
    }
    [HttpPost]
    public IActionResult Index(Student std){
        
        var data = $"Xin chào: {std.FullName}, sinh ngày {std.Birthday},đến từ: {std.Address}";
    
        
        TempData["Data"] = data;
        return RedirectToAction("Index");
    }

    public IActionResult Create(){
        ViewBag.FacultyList = new SelectList(_context.Faculties, "FacultyId", "FacultyName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student std)
    {
        std.StudentId = GenerateStudentId(std.EnrollmentYear, std.TrainingType, std.FacultyId);

        ModelState.Remove("StudentId");

        if (ModelState.IsValid) {
            
            _context.Add(std);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.FacultyList = new SelectList(_context.Faculties, "FacultyId", "FacultyName", std.FacultyId);
        return View(std);
    }
    public IActionResult Edit(string? id){
        if (id == null) return NotFound();

        var student = _context.Students.Find(id);
        if (student == null) return NotFound();
        return View(student);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(string? id, Student std){
        if (id != std.StudentId) return NotFound();

        if(ModelState.IsValid){
            _context.Update(std);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.FacultyList = new SelectList(_context.Faculties, "FacultyId", "FacultyName", std.FacultyId);
        return View(std);
    }
    public IActionResult Delete(string? id){
        if (id == null) return NotFound();

        var student = _context.Students
                              .Include(s => s.Faculty)
                              .FirstOrDefault(s => s.StudentId == id);
        if (student == null) return NotFound();
        return View(student);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirm(string id){
        var student = _context.Students.Find(id);
        if (student != null){
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }

    private string GenerateStudentId(int enrollmentYear, string trainingType, string facultyId){
        string yearPrefix = (enrollmentYear % 100).ToString("D2");
        string prefix = $"{yearPrefix}{trainingType}{facultyId}";

        var lastStudent = _context.Students.Where(s => s.StudentId.StartsWith(prefix))
                                            .OrderByDescending(s => s.StudentId)
                                            .FirstOrDefault();
        int nextSequence = 1;

        if (lastStudent != null && lastStudent.StudentId.Length >= 10) {
            string lastSequenceStr = lastStudent.StudentId.Substring(6,4);

            if (int.TryParse(lastSequenceStr, out int currentSequence)) {
                nextSequence = currentSequence + 1;
            }
        }
        return $"{prefix}{nextSequence:D4}";
    }
}
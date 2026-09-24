using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;
using DemoMVC.Data;
namespace DemoMVC.Controllers;
public class StudentController: Controller {
    private readonly ApplicationDbContext _context;

    public StudentController(ApplicationDbContext context) {
        _context = context;
    }
    public IActionResult Index(){

        List<string> majors = new List<string>{
            "CNTT",
            "Du lịch",
            "QTKD",
            "Thú Y"
        };
        ViewBag.Majors = majors;

        var students = _context.Students.ToList();

        return View(students);
    }
    [HttpPost]
    public IActionResult Index(Student std){
        
        var data = $"Xin chào: {std.FullName}, sinh ngày {std.Birthday},đến từ: {std.Address}";
    
        
        TempData["Data"] = data;
        return RedirectToAction("Index");
    }

    public IActionResult Create(){
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student std)
    {
        if (ModelState.IsValid) {
            _context.Add(std);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(std);
    }
    public IActionResult Edit(int? id){
        if (id == null) return NotFound();

        var student = _context.Students.Find(id);
        if (student == null) return NotFound();
        return View(student);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int? id, Student std){
        if (id != std.StudentId) return NotFound();

        if(ModelState.IsValid){
            _context.Update(std);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(std);
    }
    public IActionResult Delete(int? id){
        if (id == null) return NotFound();

        var student = _context.Students.Find(id);
        if (student == null) return NotFound();
        return View(student);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirm(int id){
        var student = _context.Students.Find(id);
        if (student != null){
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
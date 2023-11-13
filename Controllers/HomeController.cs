using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using mvc_app_ef.Data;
using mvc_app_ef.Models;

namespace mvc_app_ef.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _appDbContext;
    public List<Student> students = new List<Student>();

    public HomeController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IActionResult> Index()
    {
        //var sts = GetStudents();
        var sts = await _appDbContext.Students.ToListAsync();
        return View(sts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Privacy(Student student)
    {
        if (ModelState.IsValid)
        {
            // Ajusta el Kind a Utc
            student.Enrollmentdate = DateTime.SpecifyKind(student.Enrollmentdate, DateTimeKind.Utc);

            _appDbContext.Add(student);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    public List<Student> GetStudents()
    {
        List<Student> students = new List<Student>();
        students.Add(new Student { Id = 1, Lastname = "Rick", Firstmidname = "Melida", Enrollmentdate = new DateTime(2019, 05, 09, 9, 15, 0) });
        students.Add(new Student { Id = 2, Lastname = "Michael", Firstmidname = "Rodriguez", Enrollmentdate = new DateTime(2011, 12, 09, 9, 15, 0) });
        students.Add(new Student { Id = 3, Lastname = "Monica", Firstmidname = "Gonzalez", Enrollmentdate = new DateTime(2009, 05, 11, 9, 15, 0) });
        students.Add(new Student { Id = 4, Lastname = "Joe", Firstmidname = "Harrison", Enrollmentdate = new DateTime(2019, 05, 09, 9, 15, 0) });
        students.Add(new Student { Id = 5, Lastname = "Jose", Firstmidname = "Esquivel", Enrollmentdate = new DateTime(2019, 05, 09, 9, 15, 0) });

        return students;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

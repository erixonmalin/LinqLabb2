using LinqLabb2.Data;
using LinqLabb2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace LinqLabb2.Controllers
{
    public class InfoNameController : Controller
    {
        private readonly SchoolDbContext schoolDbContext;

        public InfoNameController(SchoolDbContext _schoolDbContext)
        {
            schoolDbContext = _schoolDbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<InfoNameViewModel> list = new List<InfoNameViewModel>();
            var items = await (from t in schoolDbContext.Teachers
                               join cl in schoolDbContext.Classes on t.TeacherId equals cl.FK_TeacherId
                               join s in schoolDbContext.Students on cl.ClassId equals s.FK_ClassId
                               join c in schoolDbContext.Courses on cl.FK_CourseId equals c.CourseId
                               where t.TeacherId == cl.FK_TeacherId && cl.ClassId == s.FK_ClassId
                               select new
                               {
                                   FirstName = s.FirstName,
                                   LastName = s.LastName,
                                   TFirstName = t.TFirstName,
                                   TLastName = t.TLastName,
                                   ClassName = cl.ClassName,
                                   CourseName = c.CourseName,
                               }).ToListAsync();

            foreach (var item in items)
            {
                InfoNameViewModel listItem = new InfoNameViewModel();
                listItem.FirstName = item.FirstName;
                listItem.LastName = item.LastName;
                listItem.TFirstName = item.TFirstName;
                listItem.TLastName = item.TLastName;
                listItem.ClassName = item.ClassName;
                listItem.CourseName = item.CourseName;
                list.Add(listItem);
            }

            return View(list);
        }



        public async Task<IActionResult> ResultViewSearchStudent()
        {
            List<InfoNameViewModel> list = new List<InfoNameViewModel>();
            var items = await (from s in schoolDbContext.Students
                               join cl in schoolDbContext.Classes on s.FK_ClassId equals cl.ClassId
                               join c in schoolDbContext.Courses on cl.FK_CourseId equals c.CourseId
                               join t in schoolDbContext.Teachers on cl.FK_TeacherId equals t.TeacherId
                               where c.CourseName == "Programmering 1"
                               select new
                               {
                                   FirstName = s.FirstName,
                                   LastName = s.LastName,
                                   CourseName = c.CourseName,
                                   TFirstName = t.TFirstName,
                                   TLastName = t.TLastName,
                               }).ToListAsync();

            foreach (var item in items)
            {
                InfoNameViewModel listItem = new InfoNameViewModel();
                listItem.FirstName = item.FirstName;
                listItem.LastName = item.LastName;
                listItem.CourseName = item.CourseName;
                listItem.TFirstName = item.TFirstName;
                listItem.TLastName = item.TLastName;
                list.Add(listItem);
            }

            return View(list);
        }

        public IActionResult UpdateTeacher()
        {
            return View();
        }

        public async Task<IActionResult> ChangeTeacher(string CourseName, string TLastName, string ClassName)
        {

            var currentTeacher = (from t in schoolDbContext.Teachers
                                 join cl in schoolDbContext.Classes on t.TeacherId equals cl.FK_TeacherId
                                 join c in schoolDbContext.Courses on cl.FK_CourseId equals c.CourseId
                                 join s in schoolDbContext.Students on cl.ClassId equals s.FK_ClassId
                                 where t.TeacherId == cl.FK_TeacherId && c.CourseName == CourseName && cl.ClassId == s.FK_ClassId && cl.ClassName == ClassName
                                 select t).FirstOrDefault();

            var teacherNew = (from t in schoolDbContext.Teachers
                              where t.TLastName == TLastName
                              select t).FirstOrDefault();

            var teacherUpdate = (from cl in schoolDbContext.Classes
                                 where cl.FK_TeacherId  == currentTeacher.TeacherId
                                 select cl).FirstOrDefault();

            teacherUpdate.FK_TeacherId = teacherNew.TeacherId;
            await schoolDbContext.SaveChangesAsync();

            return View();

        }

        public IActionResult UpdateCourseName()
        {
            return View();
        }

        public async Task<IActionResult> ChangeCourseName(string CurrentCourseName, string NewCourseName)
        {
            var course = (from c in schoolDbContext.Courses
                          where c.CourseName == CurrentCourseName
                          select c).FirstOrDefault();

            if (course == null)
            {
                return NotFound("Tyvärr hittades inte kursen, vänligen försök igen");
            }

            course.CourseName = NewCourseName;
            await schoolDbContext.SaveChangesAsync();

            return View();
        }
    }
}

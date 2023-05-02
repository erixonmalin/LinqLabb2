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
        //public async Task<IActionResult> SearchStudent()
        //{
        //    return View();
        //}
    }
}

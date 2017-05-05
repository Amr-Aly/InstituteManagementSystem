using InstituteManagementSystem.Models;
using InstituteManagementSystem.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace InstituteManagementSystem.Controllers
{

    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddFaculty()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFaculty(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                context.Faculties.Add(faculty);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculty);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Faculty> fac = context.Faculties.ToList();
            SelectList sl = new SelectList(fac,"Id","Name");
            ViewBag.select = sl;
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(AddDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                Faculty faculty =(Faculty) context.Faculties.Where(s => s.Id == model.FacID).FirstOrDefault();
                Department dep = new Department()
                {
                    Name = model.Name,
                    facId = faculty.Id
                };
                faculty.departments.Add(dep);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(AddCourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                Course newCourse = new Course()
                {
                    Name = course.Name,
                    NoOfCredit = course.NoOfCredit
                };
                Department dep =(Department)context.Departments.Where(d => d.Name == course.departmentName).FirstOrDefault();
                dep.Courses.Add(newCourse);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            ApplicationDbContext context = new ApplicationDbContext ();
            List<SelectListItem> genders = new List<SelectListItem>();
            SelectListItem male = new SelectListItem()
            {
                Text = "Male",
                Value = "Male"
            };
            SelectListItem female = new SelectListItem()
            {
                Text = "Female",
                Value = "Female"
            };
            genders.Add(male);
            genders.Add(female);
            ViewBag.genders = genders;

            var deps = context.Departments.ToList();

            List<SelectListItem> departments = new List<SelectListItem>();

            foreach (var d in deps)
            {
                SelectListItem dep = new SelectListItem()
                {
                    Text = d.Name,
                    Value = Convert.ToString(d.Id)
                };
                departments.Add(dep);
            }
            ViewBag.deps = departments;
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(AddStudentViewModel stud)
        {
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                Department dep = (Department)context.Departments.Where(d => d.Id == stud.Department).FirstOrDefault();
                Student student = new Student()
                {
                    Name = stud.Name,
                    Gender = stud.Gender,
                    depId = dep.Id,
                    facId = dep.facId
                };
                dep.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stud);
        }

        public ActionResult ViewStudents ()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Student> students = context.Students.ToList<Student>();

            List<DisplayStudentViewModel> studs = new List<DisplayStudentViewModel>();

            for (var i = 0; i < students.Count;i++ )
            {
                int departmentID = students[i].depId;
                Department dept = (Department)context.Departments.Where(d => d.Id == departmentID).FirstOrDefault();
                Faculty fact = (Faculty) context.Faculties.Where (f => f.Id == dept.facId).FirstOrDefault();
                DisplayStudentViewModel temp = new DisplayStudentViewModel()
                {
                    Id = students[i].Id,
                    Name = students[i].Name,
                    Gender = students[i].Gender,
                    dep = dept.Name,
                    fac = fact.Name
                };
                studs.Add(temp);
            }
            return View(studs);
        }

        [HttpGet]
        public ActionResult SearchStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ViewStudent(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Student student =(Student) context.Students.Where(s => s.Id == id).FirstOrDefault();
            int departmentID = student.depId;
            Department dept = (Department)context.Departments.Where(d => d.Id == departmentID).FirstOrDefault();
            Faculty fact = (Faculty)context.Faculties.Where(f => f.Id == dept.facId).FirstOrDefault();
            DisplayStudentViewModel temp = new DisplayStudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                Gender = student.Gender,
                dep = dept.Name,
                fac = fact.Name
            };
            return View(temp);
        }
        public ActionResult ViewStudentByName()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewStudentByName(string name)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var students = context.Students.Where(s => s.Name.Contains(name)).ToList();
            List<DisplayStudentViewModel> studs = new List<DisplayStudentViewModel>();
            for (var i = 0; i < students.Count; i++)
            {
                int departmentID = students[i].depId;
                Department dept = (Department)context.Departments.Where(d => d.Id == departmentID).FirstOrDefault();
                Faculty fact = (Faculty)context.Faculties.Where(f => f.Id == dept.facId).FirstOrDefault();
                DisplayStudentViewModel temp = new DisplayStudentViewModel()
                {
                    Id = students[i].Id,
                    Name = students[i].Name,
                    Gender = students[i].Gender,
                    dep = dept.Name,
                    fac = fact.Name
                };
                studs.Add(temp);
            }

            //var students = context.Students.Include(d => d.department).Where(s => s.Name.Contains(name)).ToList() ;

            //return View("temp",students);

            return View("ViewStudents", studs);
        }
        [HttpGet]
        public ActionResult DeleteStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteStudent(int id)
        {
            Student student;
            using(ApplicationDbContext context = new ApplicationDbContext()){
            student = (Student)context.Students.Where(s => s.Id == id).FirstOrDefault();
            }
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult BrowseFaculties ()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Faculty> faculties = context.Faculties.ToList();
            return View(faculties);
        }
    }
}
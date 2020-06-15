using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AspNetCoreFromCli.Models;
using AspNetCoreFromCli.Services;
using AspNetCoreFromCli.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFromCli.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _services;
        public HomeController(IRepository<Student> services)
        {
            _services = services;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            //var stu = new Student
            //{
            //    Id = 1,
            //    FirstName = "Nick",
            //    LastName = "Carter"
            //};
            var students = _services.GetAll();
            var vms = students.Select(x =>
                  new StudentViewModel
                  {
                      Id = x.Id,
                      Name = $"{x.FirstName}-{x.LastName}",
                      Age = DateTime.Now.Subtract(x.BirthDate).Days / 365
                  });
            HomeIndexViewModel homemodel = new HomeIndexViewModel { StudentViewModel = vms };
            return View(homemodel);
            // return Content("From HomeController");
        }

        public IActionResult Detail(int id)
        {
            var x = _services.GetById(id);

            if (x==null)
            {
                return RedirectToAction("Index");
            }
            var vm = new StudentViewModel() {

                Id = x.Id,
                Name = $"{x.FirstName}-{x.LastName}",
                Age = DateTime.Now.Subtract(x.BirthDate).Days / 365
            };
            return View(vm);
        }

        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateStudentViewModel newModel)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    FirstName = newModel.FirstName,
                    LastName = newModel.LastName,
                    BirthDate = newModel.BirthDate,
                    Sex = newModel.Sex
                };

                var model = _services.Create(student);

                return RedirectToAction(nameof(Detail), new { id = model.Id });
            }

            ModelState.AddModelError(string.Empty, "Model Error !!!");
            return View();
        }

    }
}

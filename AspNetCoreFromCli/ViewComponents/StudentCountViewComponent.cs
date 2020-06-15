using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreFromCli.Data;
using AspNetCoreFromCli.Models;
using AspNetCoreFromCli.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFromCli.ViewComponents
{
    public class StudentCountViewComponent:ViewComponent
    {
        private readonly IRepository<Student> service;

        public StudentCountViewComponent(IRepository<Student> service)
        {
            this.service = service;
        }

        public IViewComponentResult Invoke()
        {
            var count = service.GetAll().Count();
            return View("StudentCount", count);
        }
    }
}

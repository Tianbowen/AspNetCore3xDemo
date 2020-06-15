using AspNetCoreFromCli.Data;
using AspNetCoreFromCli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFromCli.Services
{
    public class EFCoreRepository : IRepository<Student>
    {
        private readonly DataContext dataContext;

        public EFCoreRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Student Create(Student model)
        {
            dataContext.Students.Add(model);
            dataContext.SaveChanges();
            return model;
        }

        public IEnumerable<Student> GetAll()
        {
            return dataContext.Students.ToList();
        }

        public Student GetById(int id)
        {
            return dataContext.Students.Find(id);
        }
    }
}

using AspNetCoreFromCli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFromCli.Services
{
    public class InMemoryRepository:IRepository<Student>
    {
        private static List<Student> _studentList;

        public InMemoryRepository()
        {
            _studentList = new List<Student>
            {
                new Student{ Id=1,FirstName="a1",LastName="b1",BirthDate=new DateTime(1932,10,2),Sex=Sex.女},
                new Student{ Id=2,FirstName="a2",LastName="b2",BirthDate=new DateTime(1962,10,2),Sex=Sex.男},
                new Student{ Id=3,FirstName="a3",LastName="b3",BirthDate=new DateTime(1998,10,2),Sex=Sex.未知},
                new Student{ Id=4,FirstName="a4",LastName="b4",BirthDate=new DateTime(1912,10,2),Sex=Sex.男},
                new Student{ Id=5,FirstName="a5",LastName="b5",BirthDate=new DateTime(1943,10,2),Sex=Sex.女}

            };
        }

        public IEnumerable<Student> GetAll()
        {

            return _studentList;
        }

        public Student GetById(int id)
        {
            return _studentList.FirstOrDefault(x => x.Id == id);
        }

        public Student Create(Student model)
        {
            int idMax = _studentList.Max(x => { return x.Id; });
            var id = idMax + 1;
            model.Id = id;
            _studentList.Add(model);
            return model;
        }



    }
}

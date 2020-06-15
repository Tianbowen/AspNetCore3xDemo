using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFromCli.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName  { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Sex Sex { get; set; }
    }
}

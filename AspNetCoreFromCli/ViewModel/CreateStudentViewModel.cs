using AspNetCoreFromCli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AspNetCoreFromCli.ViewModel
{
    public class CreateStudentViewModel
    {
        [Required,MaxLength(5)]
        [DataType(DataType.Text),DisplayName("姓名")]
        public string FirstName { get; set; }

        [Required, MaxLength(10),DisplayName("名字")]
        public string LastName { get; set; }

        [DisplayName("出生日期"),Required,DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DisplayName("性别")]
        public Sex Sex { get; set; }
    }
}

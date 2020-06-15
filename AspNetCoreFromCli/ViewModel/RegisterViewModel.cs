using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AspNetCoreFromCli.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("用户名")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("密码"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

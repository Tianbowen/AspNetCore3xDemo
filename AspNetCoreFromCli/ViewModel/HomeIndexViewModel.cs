using AspNetCoreFromCli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFromCli.ViewModel
{
    public class HomeIndexViewModel
    {
        public IEnumerable<StudentViewModel> StudentViewModel { get; set; }

    }
}

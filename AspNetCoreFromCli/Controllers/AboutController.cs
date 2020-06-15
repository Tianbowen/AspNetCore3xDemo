using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreFromCli.Controllers
{
    [Route("[controller]")]
    public class AboutController //: Controller
    {
        [Route("")]
        public string Me()
        {
            return "Me";
        }

        [Route("Company")]
        public string Company()
        {
            return "Company";
        }
    }
}

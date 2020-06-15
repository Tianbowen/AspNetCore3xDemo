using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreFromCli.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreFromCli.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}

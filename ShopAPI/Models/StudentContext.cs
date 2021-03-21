using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class StudentContext:DbContext
    {
        //无参构造函数
        public StudentContext() { }
        //有参构造函数
        public StudentContext(DbContextOptions<StudentContext> options):base(options) { }

        //容器就是表 
        public DbSet<Grade> grades { get; set; }
        public DbSet<Student> students { get; set; }
    }
}

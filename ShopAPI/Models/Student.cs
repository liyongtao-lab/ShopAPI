using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }
        public string Sname { get; set; }
        public int Age { get; set; }
        public int Gsid { get; set; }
        public string Phone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAPI.Models
{
    public class Grade
    {
        [Key]
        public int Gid { get; set; }
        public string Gname { get; set; }
    }
}

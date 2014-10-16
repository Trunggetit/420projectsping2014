using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace baptisthealth.Models
{
    [Table ("Employee")]
    public class Employee
    {
        [Key]
        public int empid { get; set; }

        public string username { get; set; }

        public string password { get; set;}

        public string lastname {get; set;}

        public string roleid { get; set; }

        public bool isactive { get; set; }
    }
}
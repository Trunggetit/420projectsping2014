using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace baptisthealth.Models
{
    [Table ("Contract")]
    public class Contract
    {
        [Key]
        public int contractid { get; set; }

        [Required]
        public string title { get; set; }

        public string description { get; set; }

        public DateTime starttime { get; set; }

        public DateTime endtime { get; set; }

        public int vendorid { get; set; }

        public int employeeid {get; set;}
    }
}
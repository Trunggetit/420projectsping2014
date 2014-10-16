using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace baptisthealth.Models
{
    [Table ("RFP")]
    public class RFP
    {
        [Key]
        public int rfpid { get; set; }

        public int empid { get; set; }

        public int commodityid { get; set; }

        public string description { get; set; }

        public decimal currentprice {get; set;}

        public decimal annualspend { get; set; }

        public int mmisnumber { get; set; }

        public int mfgnumber { get; set; }


    }
}
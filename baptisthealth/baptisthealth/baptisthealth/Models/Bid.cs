using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace baptisthealth.Models
{
    [Table ("Bid")]
    public class Bid
    {
        [Key]
        public int bidid { get; set; }

        public int vendorid { get; set; }

        public int rfpid { get; set; }

        public string comments { get; set; }

        public DateTime startdate { get; set; }

        public DateTime enddate { get; set; }

        public int vendorproductid { get; set; }
    }
}
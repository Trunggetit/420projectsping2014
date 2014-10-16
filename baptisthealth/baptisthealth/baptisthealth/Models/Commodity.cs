using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace baptisthealth.Models
{
    [Table ("Commodity")]
    public class Commodity
    {
        [Key]
        public int commodityid { get; set; }

        public string commodityname { get; set; }

        public int categoryid { get; set; }

        public string description { get; set; }
    }
}
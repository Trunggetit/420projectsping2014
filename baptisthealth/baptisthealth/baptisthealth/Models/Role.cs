using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace baptisthealth.Models
{
    [Table ("Role")]
    public class Role
    {
        [Key]
        public int roleid { get; set; }

        public string roledescription { get; set; }

        public string displayname { get; set; }

    }
}
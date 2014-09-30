using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace baptisthealth.Models
{
    public class baptisthealthdbcontext : DbContext
    {
        public baptisthealthdbcontext() : base("DefaultConnection") { }
        public DbSet<vendor> vendors { get; set; }
    }
}
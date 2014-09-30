using baptisthealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace baptisthealth.DAL.service
{
    public class vendorservice
    {
        public UnitOfWork unitofwork { get; set; }

        public void insertvendor(vendor newvendor)
        {
            unitofwork.Vendorrepository.Insert(newvendor);
            unitofwork.Save();
        }
    }
}
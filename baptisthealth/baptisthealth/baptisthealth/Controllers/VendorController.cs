using baptisthealth.DAL;
using baptisthealth.DAL.service;
using baptisthealth.helper;
using baptisthealth.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace baptisthealth.Controllers
{
    public class VendorController : Controller
    {
        private baptisthealthfunction baptisthelthfunction = new baptisthealthfunction();
        private vendorservice vendorservice = new vendorservice();
        private UnitOfWork unitOfWork = new UnitOfWork();

        public VendorController()
        {
            vendorservice.unitofwork = unitOfWork;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult registervendors()
        {
            var model = new vendor();

            return View(model);
        }

        [HttpPost]
        public ActionResult registervendors(vendor newvendoritem)
        {
            string filename = "";

            if(ModelState.IsValid)
            {
                foreach (string file in Request.Files)
                {
                    var uploadedFile = Request.Files[file];
                    string path = Server.MapPath("~/upload/vendorfileupload/");
                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }
                    uploadedFile.SaveAs(path + Path.GetFileName(uploadedFile.FileName));
                    filename = uploadedFile.FileName;
                }

                newvendoritem.taxformfilename = filename;

                vendorservice.insertvendor(newvendoritem);

                return View("vendorcompleteregistration");
            }
            return View(newvendoritem);
        }

        public ActionResult detail(int id)
        {
            vendor singlevendormodel = unitOfWork.Vendorrepository.GetByID(id);
            return View(singlevendormodel);
        }

        public ActionResult vendorcompleteregistration()
        {
            return View();
        }

        public ActionResult listofvendor()
        {
            int vendorstatus = 0;  //Declare the vendor status of 0 mean they are waiting to be approve
            return View(unitOfWork.Vendorrepository.getvendorbystatus(vendorstatus).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
	}
}
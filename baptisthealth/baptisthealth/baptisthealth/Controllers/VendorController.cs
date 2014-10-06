using System.IO;
using System.Linq;
using System.Web.Mvc;
using baptisthealth.ControllersService;
using baptisthealth.DAL;
using baptisthealth.DAL.service;
using baptisthealth.helper;
using baptisthealth.Models;

namespace baptisthealth.Controllers
{
    [Authorize]
    public class VendorController : Controller
    {
        private baptisthealthfunction _baptisthelthfunctionhelpr = new baptisthealthfunction();
        private vendorservice _vendorservice = new vendorservice();
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private readonly vendorcontrollerservice _vendorcontrollerservice;

        public VendorController()
        {
            _vendorservice.unitofwork = _unitOfWork;
            _vendorcontrollerservice = new vendorcontrollerservice(this);
        }

        //Precondition: Users click on registers 
        //Postcondition: get a new vendor registers model and make it to a form for users to enter in the websites
        [AllowAnonymous]
        public ActionResult Registervendors()
        {
            var model = new vendor(); //Declare a new vendor model

            return View(model); //Return the vendor model to the view to geneate the form
        }


        //Precondition:Users hit the registers button after everything is fill out
        //Postcondition: users data is store in the database two email will be sent one is to the sender and one to the administrations
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registervendors(vendor newvendoritem)
        {
            string filename = "";

            //After Javascript valdiation check the model on the serverside
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
                    if (uploadedFile != null)
                    {
                        uploadedFile.SaveAs(path + Path.GetFileName(uploadedFile.FileName));
                        filename = uploadedFile.FileName;
                    }
                }

                newvendoritem.taxformfilename = filename;

                _vendorservice.insertvendor(newvendoritem);

                _baptisthelthfunctionhelpr.sendmail(newvendoritem.companyname, newvendoritem.email, "we have recieved your applications");
                _baptisthelthfunctionhelpr.sendmail("Bapttisthealth", "tdngo0003@gmail.com", "a new vendor have registers");


                return View("vendorcompleteregistration");
            }
            return View(newvendoritem);
        }

        public ActionResult Detail(int id)
        {
            vendor singlevendormodel = _unitOfWork.Vendorrepository.GetByID(id);

            _vendorcontrollerservice.Getvendorstausdescriptions(singlevendormodel);

            return View(singlevendormodel);
        }

        public ActionResult Vendorcompleteregistration()
        {
            return View();
        }

        public ActionResult Listofvendor()
        {
            int vendorstatus = 0;  //Declare the vendor status of 0 mean they are waiting to be approve
            return View(_unitOfWork.Vendorrepository.getvendorbystatus(vendorstatus).ToList());
        }

        public ActionResult Acceptvendor(vendor vendor)
        {
            vendor.vendorstatus = 1;
            _unitOfWork.Vendorrepository.Update(vendor);
            _unitOfWork.Save();

            _baptisthelthfunctionhelpr.sendmail(vendor.companyname, vendor.email, "your application have been approved you can log in now");

            RegisterViewModel registermodel = new RegisterViewModel
            {
                UserName = vendor.username,
                Password = vendor.Password,
                ConfirmPassword = vendor.Password
            };

            return RedirectToAction("Customregistermethod", "Account", vendor);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
	}
}
using baptisthealth.Controllers;
using baptisthealth.Models;

namespace baptisthealth.ControllersService
{
    public class vendorcontrollerservice
    {
        private VendorController _vendorController;

        public vendorcontrollerservice(VendorController vendorController)
        {
            _vendorController = vendorController;
        }

        public void Getvendorstausdescriptions(vendor singlevendormodel)
        {
            _vendorController.ViewBag.Vendorstatus = "";

            if (singlevendormodel.vendorstatus.Equals(0))
            {
                _vendorController.ViewBag.Vendorstatus = "Waiting to be approve";
            }

            if (singlevendormodel.vendorstatus.Equals(1))
            {
                _vendorController.ViewBag.Vendorstatus = "Approve";
            }

            if (singlevendormodel.vendorstatus.Equals(1))
            {
                _vendorController.ViewBag.Vendorstatus = "Denied";
            }
        }
    }
}
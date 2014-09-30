using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace baptisthealth.Models
{
    [Table("Vendor")]
    public class vendor
    {
        [Key]
        public int vendorid { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Company Name*")]
        public string companyname { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number*")]
        public string phoneNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Fax Number*")]
        public string faxnumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Vendor*")]
        public string address { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "PO Box/Suite/Apt*")]
        public string poboxsuiteapt { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City*")]
        public string city { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State*")]
        public string state { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip/Postal Code*")]
        public string zip { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "TaxID*")]
        public string taxid { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "User name*")]
        public string username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password*")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmpassword { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Email*")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Alter Email")]
        public string altemail { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Upload Tax Form*")]
        public string taxformfilename { get; set; }

        public int vendorstatus { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssesmentProject.Models
{
    public class BaseClass {
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
    public class Contact:BaseClass {

       public Contact() {
            ContactID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            PhoneNumber = "";
            Address = "";
            City = "";
            State = "";
            Country = "";
            PostalCode = "";
            CreatedBy = 1;
            UpdatedBy = 1;
        }

        [ScaffoldColumn(false)]
        public int ContactID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Address"), MaxLength(30)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter City"), MaxLength(30)]
        [Display(Name = "City")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter State"), MaxLength(30)]
        [Display(Name = "State")]
        public string State { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Country"), MaxLength(30)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Postal Code"), MaxLength(30)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Lattitude"), MaxLength(30)]
        [Display(Name = "Geo Lattitude")]
        public string GeoLat { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter Longitude"), MaxLength(30)]
        [Display(Name = "Geo Longitude")]
        public string GeoLong { get; set; }
    }

    public class ContactInMap {

        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string PlaceName { get; set; }
        public string GeoLat { get; set; }
        public string GeoLong { get; set; }
    }
}
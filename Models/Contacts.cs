using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AssesmentProject.Models
{
    public class MasterCode
    {
		public int ID  { get; set; }
		public string CodeType { get; set; }
		public string CodeValue { get; set; }
		public string CodeDesc { get; set; }
	}
	public class Contact { 

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

		[Required(ErrorMessage = "Please enter Mobile No")]
		[Display(Name = "Phone Number")]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }

		[DataType(DataType.Text)]
		[Required(ErrorMessage = "Please enter Address"), MaxLength(30)]
		[Display(Name = "Last Name")]
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
		[Required(ErrorMessage = "Please enter Postal code"), MaxLength(30)]
		[Display(Name = "Postal Code")]
		public string PostalCode { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JumpStart1._0.Model
{
	public class ContactModel
	{
		[Required]
		[Display(Name = "First Name:")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name:")]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "Email Address:")]
		public string EmailAddress { get; set; }

		[Required]
		[Display(Name = "Message:")]
		public string Message { get; set; }
	}
}
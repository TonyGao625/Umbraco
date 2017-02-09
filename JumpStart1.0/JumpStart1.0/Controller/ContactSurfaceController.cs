using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using JumpStart1._0.Model;
using Umbraco.Web.Mvc;

namespace JumpStart1._0.Controller
{
	public class ContactSurfaceController:SurfaceController
	{
		public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Contact/";
		public ActionResult RenderForm()
		{
			return PartialView(PARTIAL_VIEW_FOLDER + "_Contact.cshtml");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SubmitForm(ContactModel model)
		{
			if (ModelState.IsValid)
			{
				SendEmail(model);
				TempData["ContactSuccess"] = true;
				return RedirectToCurrentUmbracoPage();
			}
			return CurrentUmbracoPage();
		}

		private void SendEmail(ContactModel model)
		{
			MailMessage message = new MailMessage(model.EmailAddress, "website@installumbraco.web.local");
			message.Subject = string.Format("Enquiry from {0} {1} - {2}", model.FirstName, model.LastName, model.EmailAddress);
			message.Body = model.Message;
			SmtpClient client = new SmtpClient("127.0.0.1", 25);
			client.Send(message);
		}
	}
}
using AssesmentProject.Models;
using AssesmentProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssesmentProject.Controllers
{
    public class HomeController : Controller
    {
        public Services.ContactSvc svcObj = new Services.ContactSvc();
        public ActionResult Index()
        {
            return View();
        }

        //private static List<Contact> List<Contact> rtnList { get; set; }
        //private List<Contact> GetContactsList()
        //{
        //    List<Contact> List<Contact> rtnList = new List<Contact>();
        //    Contact obj;
        //    for (int i = 1; i <= 200; i++)
        //    {
        //        obj = new Contact();
        //        obj.ContactID = i;
        //        obj.FirstName = "First Name " + i.ToString();
        //        obj.LastName = "Last Name " + i.ToString();
        //        obj.Email = "Email " + i.ToString();
        //        obj.PhoneNumber = "PhoneNumber " + i.ToString();
        //        obj.Address = "Address " + i.ToString();
        //        obj.City = "City " + i.ToString();
        //        obj.State = "State " + i.ToString();
        //        obj.Country = "Country " + i.ToString();
        //        obj.PostalCode = "PostalCode " + i.ToString();
        //        rtnList.Add(obj);
        //    }
        //    return rtnList;
        //}

        public ActionResult ContactMaster(bool? isRedirect = null, string RedirectMessage = null)
        {
            List<Contact> rtnList = svcObj.GetContactsList();

            rtnList = rtnList.OrderByDescending(x => x.ContactID).ToList();

            if (isRedirect!=null)
            {
                if ((bool)isRedirect)
                {
                    ViewData["ShowSummary"] = false;
                    ModelState.Clear();
                    ViewData["Response"] = true;
                    ViewData["SuccessMessage"] = RedirectMessage;
                }
            }

            return View(rtnList);
        }

        public ActionResult EditContact(int ContactID, bool isRedirect)
        {
            ViewData["Title"] = "Edit Contact";
            Contact obj = svcObj.GetContactsObj(ContactID);

            if (isRedirect)
            {
                ViewData["ShowSummary"] = false;
                ModelState.Clear();
                ViewData["Response"] = true;
                ViewData["SuccessMessage"] = "Contact : '" + obj.FirstName + "' has been Created successfully!";
            }

            return View(obj);
        }

        public ActionResult DeleteContact(int ContactID)
        {
            Contact obj = svcObj.GetContactsObj(ContactID);
            Response res = svcObj.Delete(obj);

            return RedirectToAction("ContactMaster", new { isRedirect = true, RedirectMessage = "Contact : " + obj.FirstName + " Deleted successflly" });
        }

        public ActionResult AddNewContact()
        {
            ViewData["Title"] = "Add New Contact";

            Contact obj = new Contact();
            obj.ContactID = -1;

            return View("EditContact",obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateContact(Contact ContactObj)
        {
            string CreateOrUpdate = "";
            CreateOrUpdate = (ContactObj.ContactID == -1) ? "created" : "updated";

            ViewData["Title"] = (ContactObj.ContactID == -1) ? "Add New Contact" : "Edit Contact";

            //Call service
            Response res = svcObj.InsertUpdate(ref ContactObj);
            if (res.status)
            {
                ViewData["ShowSummary"] = false;
                ModelState.Clear();
                ViewData["Response"] = res.status;
                ViewData["SuccessMessage"] = "Contact : '"+ ContactObj.FirstName + "' has been " + CreateOrUpdate + " successfully!";
            }
            else {
                ViewData["ShowSummary"] = false;
                if (res.Message.Contains("Email"))
                    ModelState.AddModelError("Email", res.Message);
                else if (res.Message.Contains("Phone Number"))
                    ModelState.AddModelError("PhoneNumber", res.Message);
                else
                {
                    ViewData["ShowSummary"] = true;
                    ModelState.AddModelError(string.Empty, res.Message);
                }
            }
            if (CreateOrUpdate == "created")
                return RedirectToAction("EditContact", new { ContactID = ContactObj.ContactID, isRedirect=true });
            else
                return View("EditContact", ContactObj);
        }

        public ActionResult MapView()
        {
            ViewBag.Message = "Map View";

            List<ContactInMap> rtnList = svcObj.GetContactsListInMap();

            return View(rtnList);
        }

        
    }
}
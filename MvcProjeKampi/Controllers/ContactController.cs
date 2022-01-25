using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeWeb.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager _cm = new ContactManager(new EfContactDal());
        ContactValidator _cv = new ContactValidator();
        public ActionResult Index()
        {
            var contactvalues = _cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = _cm.GetById(id);
            return View(contactvalues);
        }
    }
}
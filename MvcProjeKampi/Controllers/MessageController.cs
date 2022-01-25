using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager _mm = new MessageManager(new EfMessageDal());//62-8
        MessageValidator _messagevalidator = new MessageValidator();
        // GET: Message
        public ActionResult Inbox()
        {
            string p = (string)Session["AdminUserName"];
            var messagelist = _mm.GetListInbox(p);
           
            return View(messagelist);
        }
        //public PartialViewResult _ContactSide()
        //{
        //    var sayi = _mm.ListInboxCount();

        //    return PartialView(sayi);
        //}
        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminUserName"];
            var messagelist = _mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = _mm.GetById(id); 
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = _mm.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message m)
        {//66-14
            ValidationResult results = _messagevalidator.Validate(m);
            if (results.IsValid)
            {
                m.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _mm.MessageAdd(m);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager _cm = new ContentManager(new EfContentDal());
        WriterManager _wm = new WriterManager(new EfWriterDal());
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            
            
            //parametrem string olarak yazarın mail adresi olsun oturumu bununla yöneticem
            string p = (string)Session["WriterMail"];
            //id ye atama yapmam gerekiyor
            //ViewBag.d = p;
            int id = _wm.GetByMail(p).WriterID;
            var contentvalues = _cm.GetListByWriter(id);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content c)
        {
            int id;
            string p = (string)Session["WriterMail"];
            id = _wm.GetByMail(p).WriterID;
            c.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.WriterID = id;
            c.ContentStatus = true;
            _cm.ContentgAdd(c);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
           
            return View();
        }
    }
    
}
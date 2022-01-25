using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager _hm = new HeadingManager(new EfHeadingDal());
        CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        WriterManager _wm = new WriterManager(new EfWriterDal());
        WriterValidator _writervalidator = new WriterValidator();

        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile()
        {
            
            string p = (string)Session["WriterMail"];
           int id = _wm.GetByMail(p).WriterID;
            var wv = _wm.GetByID(id);
            return View(wv);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer w)
        {
            ValidationResult results = _writervalidator.Validate(w);
            if (results.IsValid)
            {
                _wm.WriterUpdate(w);
                return RedirectToAction("AllHeading","WriterPanel");
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
        public ActionResult MyHeading()
        {
            int id;
            //sisteme authantike olanın başlıkları gelecek
            string p = (string)Session["WriterMail"];
            id = _wm.GetByMail(p).WriterID;
            var values = _hm.GetListByWriter(id);
            return View(values);
        }
        public ActionResult AllHeading(int sayfa=1)
        {
            var headings = _hm.GetList().ToPagedList(sayfa, 4);//başlangıç sayfa dumarası ve bir sayfada kaç tane veri olacağı
            return View(headings);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in _cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            int id;
            string p = (string)Session["WriterMail"];
            id = _wm.GetByMail(p).WriterID;
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.WriterID = id;
            h.HeadingStatus=true;
            _hm.HeadingAdd(h);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in _cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            //güncellenecek değeri bu sayaya taşıyorum
            var HeadingValue = _hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            _hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = _hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            _hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }
    }
}
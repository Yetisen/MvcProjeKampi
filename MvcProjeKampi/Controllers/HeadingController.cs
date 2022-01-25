using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeWeb.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager _hm = new HeadingManager(new EfHeadingDal());
        CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        WriterManager _wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var hv = _hm.GetList();
            return View(hv);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            //ilgili tablonun bütün değerlerini alacaksın
            List<SelectListItem> valuecategory = (from x in _cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }
                                                ).ToList();

            List<SelectListItem> valuewriter = (from x in _wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName+ " "+x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }
                                                ).ToList();
            ViewBag.vlc = valuecategory;
            ViewBag.vlw = valuewriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p )
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _hm.HeadingAdd(p);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = _hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            _hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}
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

namespace MvcProjeWeb.Controllers
{
    public class WriterController : Controller
    {
        WriterManager _wm = new WriterManager(new EfWriterDal());
        WriterValidator _writervalidator = new WriterValidator();
        public ActionResult Index()
        {
            var Wv = _wm.GetList();
            return View(Wv);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            
            ValidationResult results = _writervalidator.Validate(p);
            if (results.IsValid)
            {
                _wm.WriterAdd(p);
                return RedirectToAction("Index");
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
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var wv = _wm.GetByID(id);//dışarıdan gönderdiğim id ye göre getir
            return View(wv);//sayfam dışarıdan gönderdiğim yazar ie gelecek
        }
        [HttpPost]
        public ActionResult EditWriter(Writer w)
        {
            ValidationResult results = _writervalidator.Validate(w);
            if (results.IsValid)
            {
                _wm.WriterUpdate(w);
                return RedirectToAction("Index");
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
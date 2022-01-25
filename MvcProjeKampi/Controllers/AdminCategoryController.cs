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
using System.Web.Security;

namespace MvcProjeWeb.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        //AdminManager _am = new AdminManager(new EfAdminDal());
        // GET: AdminCategory


        [Authorize(Roles ="A")]//Index sayfasını sadece giriş yapan kişiler görecek
        
        public ActionResult Index()
        {
            var categoryValue = cm.GetList();//cm den gelen tüm kategori değerlerini getir
            return View(categoryValue);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)//category sınıfına ait parametre alacaksın
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult result = cv.Validate(p);//fluent val. ile çalışıyor parametreden gelen değeri kontrol ediyoruz
            if (result.IsValid)//geçerliyse
            {
                cm.CategoryAdd(p);//parametreden gelen değeri ekle
                return RedirectToAction("Index");
            }
            else
            {
                //değilse hata fırlatacak bunu foreach ile yazdıralım
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

        public ActionResult DeleteCategory(int id)
        {
            var cv = cm.GetById(id);
            cm.CategoryDelete(cv);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var cv = cm.GetById(id);
            return View(cv);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategorUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
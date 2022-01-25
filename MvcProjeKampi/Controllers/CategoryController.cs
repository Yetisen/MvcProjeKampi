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

    public class CategoryController : Controller
    {
        CategoryManager _cm = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = _cm.GetList();
            return View(categoryvalues);//değişkene atamış old değerler view e de aktarılıyor olacak
        }
        [HttpGet]//sayfa yüklendiği zaman
        public ActionResult AddCategory()
        {
            return View();//sayfa yüklendiğinde ekleme yapma bana sadece sayfayı geri döndür
        }

        [HttpPost]//sayfada birşeye tıkladığım zaman sen çalışacaksın diyorum
        public ActionResult AddCategory(Category p)
        {
            //_cm.CategoryAddBl(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p); //gelen değerlere şartlaragöre kontrol yap
            if (results.IsValid)//sonuç geçerliyse
            {
                _cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//modelin durumuna hatayı ekle
                }
            }
            return View();
        }
    }
}
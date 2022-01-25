using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeWeb.Controllers
{

    // işin backend kısmı c# tarafı yazılır//// deneme 
    /*
    1)Entity Layer: projenin sql tarafındaki tabloların ve bu tabloların içerisinde yer alacak sütünların tanımlanacağı kısım tablolar class sütunlar property
    2)Data Access Layer: CRUD işlemleri burada tanımlanacak Filtreleme aslında listelemedir sadece bizim istediğim şartta yapılır
    3)Business Layer: Ben bu veri tabanı işlemleri sunum katmanına yansıtmadan önce benim istediğim şartların sağlanıp sağlanmadığını bu katmanda kontol edicem
    4)presentation Layer(sunum katmanı UI)(user interface kullanıcı arayüzü)
     */

    /*
     entity katmanı tablolar:Heading/Content/writer/contact/About
     */
    public class HomeController : Controller
    {
        public ActionResult Index()//genelde listeleme için kullanılır
        {
            return View();//view kısmında karşılığı olmalı
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Text()
        {

            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {

            return View();
        }
    }
}
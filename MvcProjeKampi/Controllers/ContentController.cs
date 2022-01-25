using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;

namespace MvcProjeWeb.Controllers
{
    public class ContentController : Controller
    {
        ContentManager _cm = new ContentManager(new EfContentDal());    
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = _cm.GetListByHeadingID(id);     
            return View(contentvalues);
        }
    }
}
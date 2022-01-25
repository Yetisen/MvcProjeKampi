using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        //Herkesin erişimine açık olan kısım
        HeadingManager _hm = new HeadingManager(new EfHeadingDal());
        ContentManager _cm = new ContentManager(new EfContentDal());
        public ActionResult Headings()//sol menüm olacak layout
        {
            var headingList = _hm.GetList();

            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList = _cm.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}
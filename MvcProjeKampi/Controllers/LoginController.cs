using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous] 
    public class LoginController : Controller
    {
        AdminManager _am = new AdminManager(new EfAdminDal());
        WriterLoginManager _wlm = new WriterLoginManager(new EfWriterDal());
        WriterManager _wm = new WriterManager(new EfWriterDal());

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var kontrol= _am.LoginCheck(p);
            var user = _am.GetByUser(p);

            if (kontrol)
            {
                FormsAuthentication.SetAuthCookie(user.AdminUserName, false);
                Session["AdminUserName"]=user.AdminUserName;
                return RedirectToAction("Index","AdminCategory");

            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer w)
        {
            var writeruserinfo = _wlm.GetWriter(w.WriterMail, w.WriterPassword);
            if (writeruserinfo !=null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false); //oturum yönetici için //kalıcı cookie oluşturmadık
                Session["WriterMail"] = writeruserinfo.WriterMail; //sisteme giriş yapan kişinin ismini Session yapıyorum
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
            //var kontrol = _wm.LoginCheck(w);
            //var user = _wm.GetByUser(w);

            //if (kontrol)
            //{
            //    FormsAuthentication.SetAuthCookie(user.WriterMail, false); //oturum yönetici için //kalıcı cookie oluşturmadık
            //    Session["WriterMail"] = user.WriterMail; //sisteme giriş yapan kişinin ismini Session yapıyorum
            //    return RedirectToAction("MyContent", "WriterPanelContent");

            //}
            //else
            //{
            //    return RedirectToAction("WriterLogin");
            //}
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();//ile oturumu sonlandır
            return RedirectToAction("WriterLogin","Login");
        }
    }
}
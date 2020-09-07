using MetroSMS.Business.Manager.Repository;
using MetroSMS.Data.Model.ORM.Entity;
using MetroSMS.Web.UI.Models.VM;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MetroSMS.Web.UI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : BaseController
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index([Bind(Include ="Email, Password")]AdminUserVM model)
        {


            if (ModelState.IsValid) { 
            AdminUser adminuser = unit.AdminUserRepo.FirstOrDefault(q => q.Email == model.Email);

             
            if (adminuser!=null )
            {
                    if (adminuser.RejCount == 3)
                    {
                        var response = Request["g-recaptcha-response"];
                        string secretKey = "6LdGPK8UAAAAADTZNxPfJx6H1JpWF5-eBsHqnf1m";
                        var client = new WebClient();
                        var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}&remoteip={0}", secretKey, response));
                        var obj = JObject.Parse(result);
                        var status = (bool)obj.SelectToken("success");
                        if (status==true) {
                            adminuser.LastLoginDate = DateTime.Now;
                            adminuser.RejCount = 0;
                            unit.Save();
                            FormsAuthentication.SetAuthCookie(model.Email, false);
                            return RedirectToAction("Index", "Home");
                        }
                        else { 

                        string message = ".";
                        ViewBag.MessageRejcount = message;
                        return View();
                        }
                    }
                    else { 
                    if (adminuser.Email == model.Email && adminuser.Password != model.Password)
                    {
                        adminuser.RejCount++;
                        unit.Save();
                        return View();
                    }
                        
                        
                adminuser.LastLoginDate = DateTime.Now;
                adminuser.RejCount = 0;
                unit.Save();
                FormsAuthentication.SetAuthCookie(model.Email, false);
                return RedirectToAction("Index", "Home");
                    }
                }

             
                else
                {
                  string  message = "Lütfen Email Adresinizi ve Şifrenizi Kontrol Ediniz.";
                    ViewBag.Message = message;
                    return View();
                }

            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
using MetroSMS.Business.Manager.Repository;
using MetroSMS.Data.Model.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetroSMS.Web.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {

        public UnitOfWork unit;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AdminUser adminuser = unit.AdminUserRepo.FirstOrDefault(q => q.Email.ToLower() == User.Identity.Name);
            if (adminuser != null)
            {
                ViewBag.AdminUserID = adminuser.ID;
                ViewBag.AdminUser = adminuser.Name+" "+adminuser.SurName;
            }
           
           
        }

        public BaseController()
        {
            unit = new UnitOfWork();
        }

        protected override void Dispose(bool disposing)
        {
            unit.Dispose();
            base.Dispose(disposing);
        }
    }
}
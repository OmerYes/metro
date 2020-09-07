using MetroSMS.Data.Model.ORM.Entity;
using MetroSMS.Web.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetroSMS.Web.UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {

            List<UserVM> model1 = unit.UserRepo.GetAll().Select(q => new UserVM()
            {
                ID = q.ID,
                UserWithoutPhoto = q.UserPhotos.Count(),
                TotalPhoto=q.UserPhotos.Count(),
            }).ToList();

            return View(model1);
        }
    }
}
using MetroSMS.Business.Manager.Repository;
using MetroSMS.Data.Model.ORM.Entity;
using MetroSMS.Web.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetroSMS.Web.UI.Areas.Admin.Controllers
{
    public class TableController : BaseController
    {
        public ActionResult Index()
        {
            List<UserVM> user = unit.UserRepo.GetAllQuery().Select(q => new UserVM() {
                ID = q.ID,
                Name = q.Name,
                SurName = q.SurName,
                PhoneNumber = q.PhoneNumber,
                RestourantName = q.RestourantName,
                WebSiteName = q.WebSiteName
            }).ToList();

            return View(user);
        }

        public ActionResult Detay(int id)
        {
            List<UserPhotoVM> model = unit.UserPhotoRepo.GetAllQuerableWithQuery(q=>q.UserID==id).Select(q => new UserPhotoVM()
            {
                ID = q.ID,
                Path = q.Path,
                AddDate = q.AddDate,
                
            }).ToList();

            return View(model);
        }

        public ActionResult ImgList()
        {
            List<UserPhotoVM> model = unit.UserPhotoRepo.GetAll().Select(q => new UserPhotoVM()
            {
                ID = q.ID,
                AddDate = q.AddDate,
                Path = q.Path,
                UserID=q.UserID,
                PhoneNumber = q.User.PhoneNumber,
                RestourantName = q.User.RestourantName,
                WebSiteName = q.User.WebSiteName
                
            }).OrderBy(x => x.UserID).ToList();

            List<UserPhotoVM> model2 = new List<UserPhotoVM>();

            foreach (var item in model)
            {
                var user = model2.FirstOrDefault(q => q.UserID == item.UserID);
                if (user == null)
                {
                    model2.Add(item);
                }
            }

            return View(model2);
        }

        [HttpPost]
        public JsonResult GetUserPhotos(UserPhotoVM model)
        {
            List<UserPhotoPathVM> userphotos = unit.UserPhotoRepo.GetAllQuerableWithQuery(x => x.UserID == model.ID).Select(q => new UserPhotoPathVM() {
                ID = q.ID,
                Path = q.Path
            }).ToList();
            return Json(userphotos);
        }

        class UserPhotoPathVM
        {
            public int ID { get; set; }

            public string Path { get; set; }
        }
    }
}
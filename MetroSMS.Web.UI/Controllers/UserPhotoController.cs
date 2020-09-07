using MetroSMS.Data.Model.ORM.Entity;
using MetroSMS.Web.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetroSMS.Web.UI.Controllers
{
    public class UserPhotoController : BaseController
    {
        // GET: UserPhoto
        public ActionResult Index(string phone)
        {
            var model = GetUserPhoto(phone);
            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Error");
            }

        }


        [HttpPost]
        public ActionResult Index(UserPhotoVM userPhotoVM, HttpPostedFileBase[] file)
        {

            if (!String.IsNullOrEmpty(userPhotoVM.PhoneNumber))
            {
                User user = unit.UserRepo.FirstOrDefault(q => q.PhoneNumber == userPhotoVM.PhoneNumber);
                int TotalFile = file.Count();
                UserPhotoVM photo = new UserPhotoVM();
                UserPhoto model = new UserPhoto();
                model.UserID = user.ID;
                if (file != null)
                {
                    foreach (var item in file)
                    {


                        if (item?.ContentLength >= 10485760)
                        {
                            ViewBag.IslemDurum = 0;
                            ModelState.AddModelError("mb", " 10 MB üstü dosya yükleyemezsiniz.");
                            return View();
                        }

                    }

                    int TotalFile2 = file.Count();
                    var islemsonuc = false;
                    foreach (var item in file)
                    {
                        if (TotalFile2 != 1)
                        {
                            TotalFile2--;
                            string fileName = Path.GetFileNameWithoutExtension(item.FileName);
                            string ex = Path.GetExtension(item.FileName);
                            if (ex == ".png" || ex == ".jpg" || ex == ".jpeg" || ex == ".PNG" || ex == ".JPG" || ex == ".JPEG")
                            {
                                string guid = Guid.NewGuid().ToString();
                                string sqlref = "~/Content/UserPhotos/" + guid + ex;
                                fileName = Path.Combine(Server.MapPath(sqlref));
                                item.SaveAs(fileName);
                                //ResizeImage(item);
                                model.Path = guid + ex;
                                unit.UserPhotoRepo.Add(model);
                                ViewBag.IslemDurum = 1;

                                islemsonuc = true;
                            }
                            else
                            {
                                islemsonuc = false;
                                ViewBag.IslemDurum = 0;
                                ModelState.AddModelError("mb", "Resim dışında bir dosya yükleyemezsiniz");
                                return View();
                            }


                        }
                    }

                    if (islemsonuc)
                    {
                        ViewBag.Message = "Menüleriniz başarıyla yüklendi";
                        return View();

                    }

                }
                else
                {
                    ViewBag.IslemDurum = 0;
                    ModelState.AddModelError("userid", "Lütfen gerekli alanları doldurunuz");
                    return View();
                }
            }
            else
            {
                ViewBag.IslemDurum = 0;
                ModelState.AddModelError("userid", "Lütfen gerekli alanları doldurunuz");
                return View();
            }

            return View();
        }

        public ActionResult GetFoto(UserPhotoVM userPhotoVM)
        {
            return View("Index", userPhotoVM);
        }
        public UserPhotoVM GetUserPhoto(string phonenumber)
        {
            User user = unit.UserRepo.FirstOrDefault(q => q.PhoneNumber == phonenumber);
            if (user != null)
            {
                UserPhotoVM model = new UserPhotoVM();
                model.UserID = user.ID;
                model.PhoneNumber = user.PhoneNumber;
                return model;
            }
            else
            {
                return null;
            }

        }

        public ActionResult Error()
        {
            return View();
        }

        //public void ResizeImage(HttpPostedFileBase fileToUpload)
        //{
        //    string name = Path.GetFileNameWithoutExtension(fileToUpload.FileName);
        //    var ext = Path.GetExtension(fileToUpload.FileName);
        //    string guid = Guid.NewGuid().ToString();
        //    string myfile = guid + ext;

        //    using (Image image = Image.FromStream(fileToUpload.InputStream, true, false))
        //    {

        //        var path = Path.Combine(Server.MapPath("~/Content/compresseduserphoto/"), myfile);

        //        Size can be change according to your requirement
        //        float thumbWidth = 270F;
        //        float thumbHeight = 180F;
        //        calculate image  size
        //        if (image.Width > image.Height)
        //        {
        //            thumbHeight = ((float)image.Height / image.Width) * thumbWidth;
        //        }
        //        else
        //        {
        //            thumbWidth = ((float)image.Width / image.Height) * thumbHeight;
        //        }

        //        int actualthumbWidth = Convert.ToInt32(Math.Floor(thumbWidth));
        //        int actualthumbHeight = Convert.ToInt32(Math.Floor(thumbHeight));
        //        var thumbnailBitmap = new Bitmap(actualthumbWidth, actualthumbHeight);
        //        var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
        //        thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
        //        thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
        //        thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //        var imageRectangle = new Rectangle(0, 0, actualthumbWidth, actualthumbHeight);
        //        thumbnailGraph.DrawImage(image, imageRectangle);
        //        var ms = new MemoryStream();
        //        thumbnailBitmap.Save(path, ImageFormat.Jpeg);
        //        ms.Position = 0;
        //        GC.Collect();
        //        thumbnailGraph.Dispose();
        //        thumbnailBitmap.Dispose();
        //        image.Dispose();


        //    }



        //}
    }


}
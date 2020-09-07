using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetroSMS.Web.UI.Models.VM
{
    public class UserPhotoVM:BaseVM
    {
        public string Path { get; set; }
        public int UserID { get; set; }
        public string Date { get; set; }
        public string UserPhotoName { get; set; }
        public string RestourantName { get; set; }
        public string MerlinNo { get; set; }
        public string WebSiteName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
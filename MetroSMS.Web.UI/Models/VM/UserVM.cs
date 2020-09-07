using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetroSMS.Web.UI.Models.VM
{
    public class UserVM:BaseVM
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalPhoto { get; set; }
        public int UserWithoutPhoto { get; set; }
        public int TotalUser { get; set; }
        public string RestourantName { get; set; }
        public string WebSiteName { get; set; }
    }
}
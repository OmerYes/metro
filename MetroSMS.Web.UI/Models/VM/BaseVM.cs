using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetroSMS.Web.UI.Models.VM
{
    public class BaseVM
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AddDate { get; set; }
    }
}
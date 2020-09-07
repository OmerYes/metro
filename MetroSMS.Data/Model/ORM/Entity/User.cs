using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSMS.Data.Model.ORM.Entity
{
   public class User:Base
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public string RestourantName { get; set; }
        public string MerlinNo { get; set; }
        public string WebSiteName { get; set; }
        public virtual List<UserPhoto> UserPhotos { get; set; }
    }
}

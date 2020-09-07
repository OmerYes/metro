using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSMS.Data.Model.ORM.Entity
{
    public class AdminUser : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SurName { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int RejCount { get; set; }
    }
}

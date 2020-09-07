using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MetroSMS.Web.UI.Models.VM
{
    public class AdminUserVM : BaseVM
    {
        [EmailAddress(ErrorMessage ="Geçerli Bir Email Giriniz")]
        [Required(ErrorMessage ="Email alanı zorunludur")]
        public string Email { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage ="Şifre Alanı Zorunludur")]
        public string Password { get; set; }
        public int RejCount { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
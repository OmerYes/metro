using MetroSMS.Business.Manager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MetroSMS.Web.UI.Controllers
{
    public class BaseController : Controller
    {
        public UnitOfWork unit;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diploma.Models;
using NHibernate;

namespace diploma.Controllers
{
    public class DistrictController : Controller
    {
        // GET: District
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var district = session.QueryOver<Models.Core.District>().List();
                return View(district);
            }
        }
    }
}
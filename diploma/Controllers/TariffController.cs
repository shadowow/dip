using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diploma.Models.Core;

namespace diploma.Controllers
{
    public class TariffController : Controller
    {
        // GET: Tariff
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<Tariff>().List();
                return View(t);
            }
        }
    }
}
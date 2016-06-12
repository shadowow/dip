using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using diploma.Models.Core;

namespace diploma.Controllers
{
    public class DebtController : Controller
    {
        // GET: Debt
        public ActionResult Index(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<Debt>().Where(x => x.Client.ID == id).List();
                ViewBag.Phone = session.Get<Client>(id).Phone;
                return View(t);
            }
        }

    }
}

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
        public ActionResult Index(int clientID)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<TeleStation>().Where(x => x.Clients.FirstOrDefault().ID == clientID).List();
                return View(t);
            }
        }

    }
}

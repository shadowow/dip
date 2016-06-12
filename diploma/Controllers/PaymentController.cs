using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using diploma.Models.Core;

namespace diploma.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(int clientID)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<Payment>().Where(x => x.Debt.Client.ID == clientID).List();
                return View(t);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diploma.Models.Core;
using NHibernate;

namespace diploma.Controllers
{
    public class CallController : Controller
    {
        // GET: Call
        public ActionResult Index(int clientID)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<Call>().Where(x => x.Client.ID == clientID).List();
                return View(t);
            }
        }
    }
}
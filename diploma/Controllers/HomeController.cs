using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diploma.Models.Core;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

namespace diploma.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var districts = session.QueryOver<District>().List();
                return View(districts);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Districts()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var districts = session.QueryOver<District>().List();
                return View(districts);
            }
        }
    }
}
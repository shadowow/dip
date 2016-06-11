using diploma.Models.Core;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace diploma.Controllers
{
    public class TeleStationController : Controller
    {
        // GET: TeleStation
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<TeleStation>().List();
                return View(t);
            }
        }

        // GET: TeleStation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeleStation/Create
        public ActionResult Create()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<Address>().List();
                return View(t);
            }
        }

        // POST: TeleStation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeleStation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeleStation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TeleStation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeleStation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

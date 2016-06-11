using diploma.Models.Core;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace diploma.Controllers
{
    public class PhysPersonController : Controller
    {
        // GET: PhysPerson
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<Client>().List();
                return View(t);
            }
        }

        // GET: PhysPerson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhysPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhysPerson/Create
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

        // GET: PhysPerson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhysPerson/Edit/5
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

        // GET: PhysPerson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhysPerson/Delete/5
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

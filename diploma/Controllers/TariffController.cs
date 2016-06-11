using diploma.Models.Core;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        // GET: Tariff/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.Get<Tariff>(id);
                return View(t);
            }
        }

        // GET: Tariff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tariff/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Tariff tariff = new Tariff();
                    tariff.Limitation = int.Parse(collection.Get("Limitation"));
                    tariff.LimitPrice = int.Parse(collection.Get("LimitPrice"));
                    tariff.Name = collection.Get("Name");
                    tariff.OverPrice = int.Parse(collection.Get("OverPrice"));
                    tariff.Description = collection.Get("Description");
                    ITransaction tr = session.BeginTransaction();
                    session.Save(tariff);
                    tr.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tariff/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.Get<Tariff>(id);
                return View(t);
            }
        }

        // POST: Tariff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Tariff tariff = new Tariff();
                    tariff.ID = id;
                    tariff.Limitation = int.Parse(collection.Get("Limitation"));
                    tariff.LimitPrice = int.Parse(collection.Get("LimitPrice"));
                    tariff.Name = collection.Get("Name");
                    tariff.OverPrice = int.Parse(collection.Get("OverPrice"));
                    tariff.Description = collection.Get("Description");
                    ITransaction tr = session.BeginTransaction();
                    session.Update(tariff);
                    tr.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tariff/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.Get<Tariff>(id);
                return View(t);
            }
        }

        // POST: Tariff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Tariff tariff = new Tariff();
                    tariff.ID = id;
                    ITransaction tr = session.BeginTransaction();
                    session.Delete(tariff);
                    tr.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

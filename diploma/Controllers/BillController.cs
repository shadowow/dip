using diploma.Models.Core;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace diploma.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var debts = session.QueryOver<Debt>().Where(x => x.Client.ID == id).List();
                var t = new List<Bill>();
                if (debts != null && debts.Count > 0)
                {
                    t = (List<Bill>)session.QueryOver<Bill>().Where(x => x.Debts.First().Client.ID == id).List();
                }

                ViewBag.Phone = session.Get<Client>(id).Phone;
                ViewBag.ID = id;
                return View(t);
            }
        }

        // GET: Bill/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bill/Create
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

        // GET: Bill/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bill/Edit/5
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

        // GET: Bill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bill/Delete/5
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

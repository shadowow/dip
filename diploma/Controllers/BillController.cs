using diploma.Models.Core;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
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
                IList<Bill> t = new List<Bill>();
                if (debts != null && debts.Count > 0)
                {
                    ISQLQuery query = session.CreateSQLQuery("SELECT DISTINCT b.number as \"Number\", b.\"date\" as \"Date\" FROM \"Bill\" b " + 
                        "JOIN \"debt_bill\" db ON b.number = db.bill_id " + 
                        "JOIN \"Debt\" d ON d.id = db.debt_id " + "WHERE d.client_id = " + id +
                        " ORDER BY b.number");
                    t = query.SetResultTransformer(Transformers.AliasToBean<Bill>()).List<Bill>();
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

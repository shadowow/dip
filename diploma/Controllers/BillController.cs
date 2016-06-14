using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using diploma.Models.Core;
using NHibernate.Transform;

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
                //IList<Bill> t = new List<Bill>();
                //if (debts != null && debts.Count > 0)
                //{
                //    ISQLQuery query = session.CreateSQLQuery("SELECT DISTINCT b.number as \"Number\", b.\"date\" as \"Date\" FROM \"Bill\" b " +
                //        "JOIN \"debt_bill\" db ON b.number = db.bill_id " +
                //        "JOIN \"Debt\" d ON d.id = db.debt_id " + "WHERE d.client_id = " + id +
                //        " ORDER BY b.number");
                //    t = query.SetResultTransformer(Transformers.AliasToBean<Bill>()).List<Bill>();
                //}


                IList<Bill> t = new List<Bill>();
                foreach (Debt d in debts)
                {
                    foreach (Bill b in d.Bills)
                        if (!t.Contains(b)) t.Add(b);
                }
                ViewBag.Phone = session.Get<Client>(id).Phone;
                ViewBag.ID = id;
                return View(t);
            }
        }

        public ActionResult Bills()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<Bill>().List();               
                
                return View(t);
            }
        }

        public ActionResult Add(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var debts = session.QueryOver<Debt>().Where(x => x.Client.ID == id && x.IsPaid == false).List();
                Bill bill = new Bill();
                bill.Date = DateTime.Now;
                ISet<Debt> dset = new HashSet<Debt>(debts);
                bill.Debts = dset;
                foreach (Debt d in dset)
                {
                    d.Bills.Add(bill);
                }
                ITransaction tr = session.BeginTransaction();
                session.Save(bill);
                tr.Commit();

            }
            return RedirectToAction("Index", new { id = id });
        }

        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.Get<Bill>(id);
                ViewBag.Sum = t.Debts.Sum(x => x.Amount);
                ViewBag.Client = t.Debts.FirstOrDefault().Client.Phone;
                return View(t);
            }
        }
    }
}
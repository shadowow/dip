using diploma.Models.Core;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace diploma.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<Address>().List();
                return View(t);
            }
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var result = session.Get<Address>(id);
                return View(result);
            }
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Address address = new Address();
                address.PostOffice = collection.Get("PostOffice");
                address.Street = collection.Get("Street");
                address.Building = collection.Get("Building");
                address.District = collection.Get("District");
                address.Extra = collection.Get("Extra");
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ITransaction tr = session.BeginTransaction();
                    session.Save(address);
                    tr.Commit();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var result = session.Get<Address>(id);
                return View(result);
            }
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Address address = new Address();
                address.ID = id;
                address.PostOffice = collection.Get("PostOffice");
                address.Street = collection.Get("Street");
                address.Building = collection.Get("Building");
                address.District = collection.Get("District");
                address.Extra = collection.Get("Extra");
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ITransaction tr = session.BeginTransaction();
                    session.Update(address);
                    tr.Commit();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var result = session.Get<Address>(id);
                return View(result);
            }
        }

        // POST: Address/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Address address = new Address();
                    address.ID = id;
                    ITransaction tr = session.BeginTransaction();
                    session.Delete(address);
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

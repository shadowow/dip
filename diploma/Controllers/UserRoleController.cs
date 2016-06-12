
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using diploma.Models.Accounts;

namespace diploma.Controllers
{
    public class UserRoleController : Controller
    {
        // GET: UserRole
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<UserRole>().List();
                return View(t);
            }
        }

        // GET: UserRole/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.Get<UserRole>(id);
                return View(t);
            }
        }

        // GET: UserRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRole/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
         //   try
            {
                // TODO: Add insert logic here
                UserRole role = new UserRole();
                role.Name = collection.Get("Name");
                role.CanEditPersonal = Convert.ToBoolean(collection["CanEditPersonal"]);
                role.CanEditReference = Convert.ToBoolean(collection["CanEditReference"]);
                role.CanEditUsers = Convert.ToBoolean(collection["CanEditUsers"]); 
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ITransaction tr = session.BeginTransaction();
                    session.Save(role);
                    tr.Commit();
                }
                return RedirectToAction("Index");
            }
        //    catch
            {
                return View();
            }
        }

        // GET: UserRole/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var result = session.Get<UserRole>(id);
                return View(result);
            }
        }

        // POST: UserRole/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                UserRole role = new UserRole();
                role.ID = id;
                role.Name = collection.Get("Name");
                role.CanEditPersonal = Boolean.Parse(collection.Get("CanEditPersonal"));
                role.CanEditReference = Boolean.Parse(collection.Get("CanEditReference"));
                role.CanEditUsers = Boolean.Parse(collection.Get("CanEditUsers"));
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    ITransaction tr = session.BeginTransaction();
                    session.Save(role);
                    tr.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRole/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var result = session.Get<UserRole>(id);
                return View(result);
            }
        }

        // POST: UserRole/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    UserRole role = new UserRole();
                    role.ID = id;
                    ITransaction tr = session.BeginTransaction();
                    session.Delete(role);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using diploma.Models.Accounts;

namespace diploma.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.QueryOver<User>().List();
                return View(t);
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.Get<User>(id);
                return View(t);
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var roles = session.QueryOver<UserRole>().List();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (UserRole r in roles)
                {
                    items.Add(new SelectListItem { Text = r.Name, Value = r.ID.ToString() });
                }

                ViewBag.Roles = items;
                return View();
            }
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    UserRole role = session.Get<UserRole>(int.Parse(collection.Get("Roles")));
                    User user = new User();
                    user.Login = collection.Get("Login");
                    user.Password = collection.Get("Password");
                    user.Role = role;
                    ITransaction tr = session.BeginTransaction();
                    session.Save(user);
                    tr.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var roles = session.QueryOver<UserRole>().List();
                var m = session.Get<User>(id);
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (UserRole r in roles)
                {
                    if (r.ID == m.Role.ID)
                    {
                        items.Add(new SelectListItem { Text = r.ToString(), Value = r.ID.ToString(), Selected = true });
                    }
                    else
                    {
                        items.Add(new SelectListItem { Text = r.ToString(), Value = r.ID.ToString(), Selected = false });
                    }
                }

                ViewBag.Roles = items;
                return View(m);
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    UserRole role = session.Get<UserRole>(int.Parse(collection.Get("Roles")));
                    User user = new User();
                    user.ID = id;
                    user.Login = collection.Get("Login");
                    user.Password = collection.Get("Password");
                    user.Role = role;
                    ITransaction tr = session.BeginTransaction();
                    session.Save(user);
                    tr.Commit();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var t = session.Get<User>(id);
                return View(t);
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    User u = new User();
                    u.ID = id;
                    ITransaction tr = session.BeginTransaction();
                    session.Delete(u);
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

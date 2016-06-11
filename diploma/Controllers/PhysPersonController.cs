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
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var addresses = session.QueryOver<Address>().List();
                List<SelectListItem> itemsAddr = new List<SelectListItem>();
                List<SelectListItem> itemsRegAddr = new List<SelectListItem>();
                foreach (Address a in addresses)
                {
                    itemsAddr.Add(new SelectListItem { Text = a.ToString(), Value = a.ID.ToString() });
                    itemsRegAddr.Add(new SelectListItem { Text = a.ToString(), Value = a.ID.ToString() });
                }
                ViewBag.LivingAddresses = itemsAddr;
                ViewBag.RegistrationAddresses = itemsRegAddr;

                var stations = session.QueryOver<TeleStation>().List();
                List<SelectListItem> itemsStation = new List<SelectListItem>();
                foreach (TeleStation a in stations)
                {
                    itemsStation.Add(new SelectListItem { Text = a.ToString(), Value = a.ID.ToString() });
                }
                ViewBag.Stations = itemsStation;

                var tariffs = session.QueryOver<Tariff>().List();
                List<SelectListItem> itemsTariff = new List<SelectListItem>();
                foreach (Tariff a in tariffs)
                {
                    itemsTariff.Add(new SelectListItem { Text = a.Name, Value = a.ID.ToString() });
                }
                ViewBag.Tariffs = itemsTariff;
                ViewData["Stations"] = itemsStation;
                ViewData["Tariffs"] = itemsTariff;
                ViewData["LivingAddresses"] = itemsAddr;
                ViewData["RegistrationAddresses"] = itemsRegAddr;

                return View();
            }
        }

        // POST: PhysPerson/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    Address livAddress = session.Get<Address>(int.Parse(collection.Get("LivingAddresses")));
                    Address regAddress = session.Get<Address>(int.Parse(collection.Get("RegistrationAddresses")));
                    TeleStation station = session.Get<TeleStation>(int.Parse(collection.Get("Stations")));
                    Tariff tariff = session.Get<Tariff>(int.Parse(collection.Get("Tariffs")));

                    Client client = new Client();
                    client.IsLegalEntity = false;
                    client.Phone = collection.Get("Phone");
                    client.Address = livAddress;
                    client.CurrentTariff = tariff;
                    client.Station = station;
                    client.PhysPerson = new PhysPerson();
                    client.PhysPerson.CurrentAddress = regAddress;
                    client.PhysPerson.FirstName = collection.Get("FirstName");
                    client.PhysPerson.Surname = collection.Get("Surname");
                    client.PhysPerson.Patronimyc = collection.Get("Patronimyc");
                    client.PhysPerson.PassportNumber = collection.Get("PassportNumber");
                    client.PhysPerson.SerialNumber = int.Parse(collection.Get("SerialNumber"));
                    client.PhysPerson.DateOfIssue = DateTime.Parse(collection.Get("DateOfIssue"));
                    client.PhysPerson.PlaceOfIssue = collection.Get("PlaceOfIssue");
                    ITransaction tr = session.BeginTransaction();
                    session.Save(client);
                    tr.Commit();
                }
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

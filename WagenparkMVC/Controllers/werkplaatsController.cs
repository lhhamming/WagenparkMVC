using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WagenparkMVC.Models;

namespace WagenparkMVC.Controllers
{
    public class werkplaatController : Controller
    {
        private AutoEntities db = new AutoEntities();

        // GET: werkplaat
        public ActionResult Index()
        {
            return View(db.werkplaat.ToList());
        }

        // GET: werkplaat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            werkplaat werkplaat = db.werkplaat.Find(id);
            if (werkplaat == null)
            {
                return HttpNotFound();
            }
            return View(werkplaat);
        }

        // GET: werkplaat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: werkplaat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "werkplaatnr,naam")] werkplaat werkplaat)
        {
            if (ModelState.IsValid)
            {
                db.werkplaat.Add(werkplaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(werkplaat);
        }

        // GET: werkplaat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            werkplaat werkplaat = db.werkplaat.Find(id);
            if (werkplaat == null)
            {
                return HttpNotFound();
            }
            return View(werkplaat);
        }

        // POST: werkplaat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "werkplaatnr,naam")] werkplaat werkplaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(werkplaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(werkplaat);
        }

        // GET: werkplaat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            werkplaat werkplaat = db.werkplaat.Find(id);
            if (werkplaat == null)
            {
                return HttpNotFound();
            }
            return View(werkplaat);
        }

        // POST: werkplaat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            werkplaat werkplaat = db.werkplaat.Find(id);
            db.werkplaat.Remove(werkplaat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

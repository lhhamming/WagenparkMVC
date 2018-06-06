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
    public class werkplaatsController : Controller
    {
        private AutoEntities db = new AutoEntities();

        // GET: werkplaats
        public ActionResult Index()
        {
            return View(db.werkplaats.ToList());
        }

        // GET: werkplaats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            werkplaats werkplaats = db.werkplaats.Find(id);
            if (werkplaats == null)
            {
                return HttpNotFound();
            }
            return View(werkplaats);
        }

        // GET: werkplaats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: werkplaats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "werkplaatsnr,naam")] werkplaats werkplaats)
        {
            if (ModelState.IsValid)
            {
                db.werkplaats.Add(werkplaats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(werkplaats);
        }

        // GET: werkplaats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            werkplaats werkplaats = db.werkplaats.Find(id);
            if (werkplaats == null)
            {
                return HttpNotFound();
            }
            return View(werkplaats);
        }

        // POST: werkplaats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "werkplaatsnr,naam")] werkplaats werkplaats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(werkplaats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(werkplaats);
        }

        // GET: werkplaats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            werkplaats werkplaats = db.werkplaats.Find(id);
            if (werkplaats == null)
            {
                return HttpNotFound();
            }
            return View(werkplaats);
        }

        // POST: werkplaats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            werkplaats werkplaats = db.werkplaats.Find(id);
            db.werkplaats.Remove(werkplaats);
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

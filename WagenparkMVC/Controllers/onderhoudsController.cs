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
    public class onderhoudsController : Controller
    {
        private AutoEntities db = new AutoEntities();

        // GET: onderhouds
        public ActionResult Index()
        {
            var onderhoud = db.onderhouds.Include(o => o.auto).Include(o => o.werkplaat);
            return View(onderhoud.ToList());
        }

        // GET: onderhouds/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            onderhoud onderhoud = db.onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // GET: onderhouds/Create
        public ActionResult Create()
        {
            ViewBag.auto_kenteken = new SelectList(db.autoes, "kenteken", "merk");
            ViewBag.werkplaat_werkplaatnr = new SelectList(db.werkplaats, "werkplaatsnr", "naam");
            return View();
        }

        // POST: onderhouds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "onderhoudsdatum,kosten,auto_kenteken,werkplaat_werkplaatnr")] onderhoud onderhoud)
        {
            if (ModelState.IsValid)
            {
                db.onderhouds.Add(onderhoud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.auto_kenteken = new SelectList(db.autoes, "kenteken", "merk", onderhoud.auto_kenteken);
            ViewBag.werkplaat_werkplaatnr = new SelectList(db.werkplaats, "werkplaatsnr", "naam", onderhoud.werkplaats_werkplaatsnr);
            return View(onderhoud);
        }

        // GET: onderhouds/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            onderhoud onderhoud = db.onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            ViewBag.auto_kenteken = new SelectList(db.autoes, "kenteken", "merk", onderhoud.auto_kenteken);
            ViewBag.werkplaat_werkplaatnr = new SelectList(db.werkplaats, "werkplaatnr", "naam", onderhoud.werkplaats_werkplaatsnr);
            return View(onderhoud);
        }

        // POST: onderhouds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "onderhoudsdatum,kosten,auto_kenteken,werkplaat_werkplaatnr")] onderhoud onderhoud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onderhoud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.auto_kenteken = new SelectList(db.autoes, "kenteken", "merk", onderhoud.auto_kenteken);
            ViewBag.werkplaat_werkplaatnr = new SelectList(db.werkplaats, "werkplaatnr", "naam", onderhoud.werkplaats_werkplaatsnr);
            return View(onderhoud);
        }

        // GET: onderhouds/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            onderhoud onderhoud = db.onderhouds.Find(id);
            if (onderhoud == null)
            {
                return HttpNotFound();
            }
            return View(onderhoud);
        }

        // POST: onderhouds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            onderhoud onderhoud = db.onderhouds.Find(id);
            db.onderhouds.Remove(onderhoud);
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

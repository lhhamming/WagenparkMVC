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
    public class autoesController : Controller
    {
        private AutoEntities db = new AutoEntities();

        // GET: autoes
        public ActionResult Index()
        {
            var auto = db.autoes.Include(a => a.dealer);
            return View(auto.ToList());
        }

        // GET: autoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // GET: autoes/Create
        public ActionResult Create()
        {
            ViewBag.DEALER_dealernr = new SelectList(db.dealers, "dealernr", "naam");
            return View();
        }

        // POST: autoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kenteken,merk,Type,DEALER_dealernr")] auto auto)
        {
            if (ModelState.IsValid)
            {
                db.autoes.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEALER_dealernr = new SelectList(db.dealers, "dealernr", "naam", auto.DEALER_DealerNr);
            return View(auto);
        }

        // GET: autoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEALER_dealernr = new SelectList(db.dealers, "dealernr", "naam", auto.DEALER_DealerNr);
            return View(auto);
        }

        // POST: autoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kenteken,merk,Type,DEALER_dealernr")] auto auto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEALER_dealernr = new SelectList(db.dealers, "dealernr", "naam", auto.DEALER_DealerNr);
            return View(auto);
        }

        // GET: autoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auto auto = db.autoes.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        // POST: autoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            auto auto = db.auto.Find(id);
            db.auto.Remove(auto);
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

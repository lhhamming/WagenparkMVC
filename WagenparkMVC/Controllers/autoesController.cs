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
    [Authorize]
    public class autoesController : Controller
    {
        private AutoEntities db = new AutoEntities();

        // GET: autoes
        public ActionResult Index()
        {
            if (User.IsInRole("Bosmans"))
            {
                var BosmansAuto = db.autoes.Include(d => d.dealer).Where(u => u.DEALER_DealerNr == 1);
                return View(BosmansAuto.ToList());
            }
            if (User.IsInRole("Vroegop"))
            {
                var VroegopAuto = db.autoes.Include(d => d.dealer).Where(u => u.DEALER_DealerNr == 2);
                return View(VroegopAuto.ToList());
            }
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
            if (User.IsInRole("Bosmans"))
            {
                ViewBag.DEALER_dealernr = new SelectList(db.dealers.Where(u => u.dealernr == 1), "dealernr", "naam");
                return View();
            }
            if (User.IsInRole("Vroegop"))
            {
                ViewBag.DEALER_dealernr = new SelectList(db.dealers.Where(u => u.dealernr == 2), "dealernr", "naam");
                return View();
            }
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
            auto auto = db.autoes.Find(id);
            db.autoes.Remove(auto);
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

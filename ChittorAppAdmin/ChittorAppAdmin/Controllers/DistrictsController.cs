using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChittorAPPAdmin.Entities;
using ChittorAPPAdmin.Models;

namespace ChittorAPPAdmin.Controllers
{
    [Authorize]
    public class DistrictsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Districts/
        public ActionResult Index()
        {
            var districts = db.Districts.Include(d => d.States);
            return View(districts.ToList());
        }

        // GET: /Districts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Districts districts = db.Districts.Find(id);
            if (districts == null)
            {
                return HttpNotFound();
            }
            return View(districts);
        }

        // GET: /Districts/Create
        public ActionResult Create()
        {
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName");
            return View();
        }

        // POST: /Districts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DistrictName,StateID")] Districts districts)
        {
            districts.ID = Guid.NewGuid().ToString();
           
                db.Districts.Add(districts);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: /Districts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Districts districts = db.Districts.Find(id);
            if (districts == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", districts.StateID);
            return View(districts);
        }

        // POST: /Districts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,DistrictName,StateID")] Districts districts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(districts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateID = new SelectList(db.States, "StateID", "StateName", districts.StateID);
            return View(districts);
        }

        // GET: /Districts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Districts districts = db.Districts.Find(id);
            if (districts == null)
            {
                return HttpNotFound();
            }
            return View(districts);
        }

        // POST: /Districts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Districts districts = db.Districts.Find(id);
            db.Districts.Remove(districts);
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

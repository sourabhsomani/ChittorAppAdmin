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
using Microsoft.AspNet.Identity;

namespace ChittorAPPAdmin.Controllers
{
    [Authorize]
    public class SubAreaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /SubArea/
        public ActionResult Index()
        {
            var subareas = db.SubAreas.Include(s => s.Areas);
            return View(subareas.ToList());
        }

        // GET: /SubArea/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubArea subarea = db.SubAreas.Find(id);
            if (subarea == null)
            {
                return HttpNotFound();
            }
            return View(subarea);
        }

        // GET: /SubArea/Create
        public ActionResult Create()
        {
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "AreaName");
            return View();
        }

        // POST: /SubArea/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SubAreaName,AreaID")] SubArea subarea)
        {
            subarea.ID = Guid.NewGuid().ToString();
            subarea.AddedBy = User.Identity.GetUserId();
            subarea.ModifiedBy = User.Identity.GetUserId();
            subarea.AddedDate = DateTime.Now;
            subarea.ModifiedDate = DateTime.Now;

                db.SubAreas.Add(subarea);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: /SubArea/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubArea subarea = db.SubAreas.Find(id);
            if (subarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "AreaName", subarea.AreaID);
            return View(subarea);
        }

        // POST: /SubArea/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,SubAreaName,AreaID,AddedBy,ModifiedBy,AddedDate,ModifiedDate")] SubArea subarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaID = new SelectList(db.Areas, "ID", "AreaName", subarea.AreaID);
            return View(subarea);
        }

        // GET: /SubArea/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubArea subarea = db.SubAreas.Find(id);
            if (subarea == null)
            {
                return HttpNotFound();
            }
            return View(subarea);
        }

        // POST: /SubArea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SubArea subarea = db.SubAreas.Find(id);
            db.SubAreas.Remove(subarea);
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

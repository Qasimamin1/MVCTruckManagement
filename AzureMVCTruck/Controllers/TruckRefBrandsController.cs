using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzureMVCTruck.Models;

namespace AzureMVCTruck.Controllers
{
 [CustomAuthorize (Roles = "supervisor")]
    public class TruckRefBrandsController : Controller
    {
        private AzureMVCDeployementEntities db = new AzureMVCDeployementEntities();

        // GET: TruckRefBrands
        public ActionResult Index()
        {
            return View(db.TruckRefBrands.ToList());
        }

        // GET: TruckRefBrands/Details/5
        public ActionResult Details(int? id)   
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckRefBrand truckRefBrand = db.TruckRefBrands.Find(id);
            if (truckRefBrand == null)
            {
                return HttpNotFound();
            }
            return View(truckRefBrand);
        }

        // GET: TruckRefBrands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TruckRefBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TruckRefBrandID,TruckRefBrandName")] TruckRefBrand truckRefBrand)
        {
            if (ModelState.IsValid)
            {
                db.TruckRefBrands.Add(truckRefBrand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(truckRefBrand);
        }

        // GET: TruckRefBrands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckRefBrand truckRefBrand = db.TruckRefBrands.Find(id);
            if (truckRefBrand == null)
            {
                return HttpNotFound();
            }
            return View(truckRefBrand);
        }

        // POST: TruckRefBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TruckRefBrandID,TruckRefBrandName")] TruckRefBrand truckRefBrand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truckRefBrand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(truckRefBrand);
        }

        // GET: TruckRefBrands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckRefBrand truckRefBrand = db.TruckRefBrands.Find(id);
            if (truckRefBrand == null)
            {
                return HttpNotFound();
            }
            return View(truckRefBrand);
        }

        // POST: TruckRefBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TruckRefBrand truckRefBrand = db.TruckRefBrands.Find(id);
            db.TruckRefBrands.Remove(truckRefBrand);
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

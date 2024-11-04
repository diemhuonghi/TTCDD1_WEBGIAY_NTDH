using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webgiay_NTDH.Models;

namespace webgiay_NTDH.Controllers
{
    public class DANH_GIA_SAN_PHAMController : Controller
    {
        private ntdh__webEntities db = new ntdh__webEntities();

        // GET: DANH_GIA_SAN_PHAM
        public ActionResult Index()
        {
            var dANH_GIA_SAN_PHAM = db.DANH_GIA_SAN_PHAM.Include(d => d.KHACH_HANG).Include(d => d.SAN_PHAM);
            return View(dANH_GIA_SAN_PHAM.ToList());
        }

        // GET: DANH_GIA_SAN_PHAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA_SAN_PHAM dANH_GIA_SAN_PHAM = db.DANH_GIA_SAN_PHAM.Find(id);
            if (dANH_GIA_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(dANH_GIA_SAN_PHAM);
        }

        // GET: DANH_GIA_SAN_PHAM/Create
        public ActionResult Create()
        {
            ViewBag.customerID = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten");
            ViewBag.ProductID = new SelectList(db.SAN_PHAM, "ProductID", "Ten_san_pham");
            return View();
        }

        // POST: DANH_GIA_SAN_PHAM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,ProductID,customerID,Diem_danh_gia,Nhan_xet,Ngay_danh_gia")] DANH_GIA_SAN_PHAM dANH_GIA_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.DANH_GIA_SAN_PHAM.Add(dANH_GIA_SAN_PHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dANH_GIA_SAN_PHAM.customerID);
            ViewBag.ProductID = new SelectList(db.SAN_PHAM, "ProductID", "Ten_san_pham", dANH_GIA_SAN_PHAM.ProductID);
            return View(dANH_GIA_SAN_PHAM);
        }

        // GET: DANH_GIA_SAN_PHAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA_SAN_PHAM dANH_GIA_SAN_PHAM = db.DANH_GIA_SAN_PHAM.Find(id);
            if (dANH_GIA_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dANH_GIA_SAN_PHAM.customerID);
            ViewBag.ProductID = new SelectList(db.SAN_PHAM, "ProductID", "Ten_san_pham", dANH_GIA_SAN_PHAM.ProductID);
            return View(dANH_GIA_SAN_PHAM);
        }

        // POST: DANH_GIA_SAN_PHAM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,ProductID,customerID,Diem_danh_gia,Nhan_xet,Ngay_danh_gia")] DANH_GIA_SAN_PHAM dANH_GIA_SAN_PHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dANH_GIA_SAN_PHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.KHACH_HANG, "MaKH", "Ho_ten", dANH_GIA_SAN_PHAM.customerID);
            ViewBag.ProductID = new SelectList(db.SAN_PHAM, "ProductID", "Ten_san_pham", dANH_GIA_SAN_PHAM.ProductID);
            return View(dANH_GIA_SAN_PHAM);
        }

        // GET: DANH_GIA_SAN_PHAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DANH_GIA_SAN_PHAM dANH_GIA_SAN_PHAM = db.DANH_GIA_SAN_PHAM.Find(id);
            if (dANH_GIA_SAN_PHAM == null)
            {
                return HttpNotFound();
            }
            return View(dANH_GIA_SAN_PHAM);
        }

        // POST: DANH_GIA_SAN_PHAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DANH_GIA_SAN_PHAM dANH_GIA_SAN_PHAM = db.DANH_GIA_SAN_PHAM.Find(id);
            db.DANH_GIA_SAN_PHAM.Remove(dANH_GIA_SAN_PHAM);
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

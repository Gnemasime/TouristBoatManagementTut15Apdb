using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TouristBoatManagementTut15Apdb.Models;

namespace TouristBoatManagementTut15Apdb.Controllers 
{
    public class CaptainPerfomanceVIewModelsController : Controller
    {
        private TourContext db = new TourContext();

        // GET: CaptainPerfomanceVIewModels
        public ActionResult Index()
        {
            // return View(db.captainPerfomanceVIews.ToList());
            List<CaptainPerfomanceVIewModel> captainPerfomanceVIews = new List<CaptainPerfomanceVIewModel>();
            var CaptainList = (from ca in db.captains
                               join to in db.tours on ca.CaptainId equals to.CaptainId
                               join bo in db.boats on ca.AssignedBoatId equals bo.BoatId
                               where to.IsCompleted == true
                               group to by new { ca.CaptainId, ca.Name, ca.LicenseType, ca.ExperiencePoints } into captainGroup
                               select new
                               {
                                   captainGroup.Key.Name,
                                   captainGroup.Key.LicenseType,
                                   captainGroup.Key.ExperiencePoints,
                                   TotalEarnings = captainGroup.Sum(t => t.TourIncome),
                                   AverageRating = captainGroup.Average(t => t.Rating)
                               }).ToList();

            foreach ( var captain in CaptainList)
            {
                CaptainPerfomanceVIewModel model = new CaptainPerfomanceVIewModel();
                model.Name = captain.Name;
                model.LicenseType = captain.LicenseType;
                model.ExperiencePoints = captain.ExperiencePoints;
                model.TotalEarnings = captain.TotalEarnings;
                model.AverageTourRatings = (int)captain.AverageRating;

                captainPerfomanceVIews.Add(model);
            }

            return View(captainPerfomanceVIews);
        }

        // GET: CaptainPerfomanceVIewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaptainPerfomanceVIewModel captainPerfomanceVIewModel = db.captainPerfomanceVIews.Find(id);
            if (captainPerfomanceVIewModel == null)
            {
                return HttpNotFound();
            }
            return View(captainPerfomanceVIewModel);
        }

        // GET: CaptainPerfomanceVIewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaptainPerfomanceVIewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaptainViewId,Name,LicenseType,ExperiencePoints,TotalEarnings,TourRatings")] CaptainPerfomanceVIewModel captainPerfomanceVIewModel)
        {
            if (ModelState.IsValid)
            {
                db.captainPerfomanceVIews.Add(captainPerfomanceVIewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(captainPerfomanceVIewModel);
        }

        // GET: CaptainPerfomanceVIewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaptainPerfomanceVIewModel captainPerfomanceVIewModel = db.captainPerfomanceVIews.Find(id);
            if (captainPerfomanceVIewModel == null)
            {
                return HttpNotFound();
            }
            return View(captainPerfomanceVIewModel);
        }

        // POST: CaptainPerfomanceVIewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaptainViewId,Name,LicenseType,ExperiencePoints,TotalEarnings,TourRatings")] CaptainPerfomanceVIewModel captainPerfomanceVIewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(captainPerfomanceVIewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(captainPerfomanceVIewModel);
        }

        // GET: CaptainPerfomanceVIewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaptainPerfomanceVIewModel captainPerfomanceVIewModel = db.captainPerfomanceVIews.Find(id);
            if (captainPerfomanceVIewModel == null)
            {
                return HttpNotFound();
            }
            return View(captainPerfomanceVIewModel);
        }

        // POST: CaptainPerfomanceVIewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaptainPerfomanceVIewModel captainPerfomanceVIewModel = db.captainPerfomanceVIews.Find(id);
            db.captainPerfomanceVIews.Remove(captainPerfomanceVIewModel);
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

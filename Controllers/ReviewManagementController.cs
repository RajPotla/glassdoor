using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Glassdoor.Controllers
{
    public class ReviewManagementController : Controller
    {
        // GET: ReviewManagement
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,Description,Date_Created, User_ID,Job_ID")] ReviewManagementController Review)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Review.id = Guid.NewGuid();
                    Review.Date_Created = DateTime.Today;
                    db.Review.Add(review);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (InvalidDataException)
            {
                ModelState.AddModelError("", "Unable to save changes, Try again!");
            }

            return View(Review);
        }
        
        // POST: Sellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Guid? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ReviewManagementController reviewToUpdate = db.ReviewManagementController.Find(id);
            if(TryUpdateModel(reviewToUpdate, "", new string[] { "Description", "Date_Created", "User_ID", "Job_ID" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (InvalidDataException)
                {
                    ModelState.AddModelError("", "Unable to save Changes, Try Again!");
                }
            }

            return View(reviewToUpdate);
        }
        
    }
}

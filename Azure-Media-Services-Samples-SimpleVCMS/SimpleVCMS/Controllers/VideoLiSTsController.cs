using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleVCMS.Models;

namespace SimpleVCMS.Controllers
{
    public class VideoLiSTsController : Controller
    {
        private vCMS db = new vCMS();

        // GET: VideoLiSTs
        public ActionResult Index()
        {
            return View(db.VideoLiST.ToList());
        }

        // GET: VideoLiSTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoLiST videoLiST = db.VideoLiST.Find(id);
            if (videoLiST == null)
            {
                return HttpNotFound();
            }
            return View(videoLiST);
        }

        // GET: VideoLiSTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoLiSTs/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileName,Title,Description,PlayerURL,CCja,CCen,CCfr,CCde,CCko,CCzhCHS,CCes")] VideoLiST videoLiST)
        {
            if (ModelState.IsValid)
            {
                db.VideoLiST.Add(videoLiST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoLiST);
        }

        // GET: VideoLiSTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoLiST videoLiST = db.VideoLiST.Find(id);
            if (videoLiST == null)
            {
                return HttpNotFound();
            }
            return View(videoLiST);
        }

        // POST: VideoLiSTs/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileName,Title,Description,PlayerURL,CCja,CCen,CCfr,CCde,CCko,CCzhCHS,CCes")] VideoLiST videoLiST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoLiST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoLiST);
        }

        // GET: VideoLiSTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoLiST videoLiST = db.VideoLiST.Find(id);
            if (videoLiST == null)
            {
                return HttpNotFound();
            }
            return View(videoLiST);
        }

        // POST: VideoLiSTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VideoLiST videoLiST = db.VideoLiST.Find(id);
            db.VideoLiST.Remove(videoLiST);
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

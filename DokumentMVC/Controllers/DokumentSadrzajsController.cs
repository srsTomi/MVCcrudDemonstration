using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DokumentMVC.Models;


namespace DokumentMVC.Controllers
{
    public class DokumentSadrzajsController : Controller
    {
        private DokumentSadrzajContext db = new DokumentSadrzajContext();

       
        public ActionResult Index()
        {
            return View(db.DokumentSadrzaji.ToList());
        }

    
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DokumentSadrzaj dokumentSadrzaj = db.DokumentSadrzaji.Find(id);
            if (dokumentSadrzaj == null)
            {
                return HttpNotFound();
            }
            return View(dokumentSadrzaj);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Naziv,Kolicina,TipUlaza")] DokumentSadrzaj dokumentSadrzaj)
        {
            if (ModelState.IsValid)
            {
                dokumentSadrzaj.Datum = DateTime.Now;
                db.DokumentSadrzaji.Add(dokumentSadrzaj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dokumentSadrzaj);
        }

       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DokumentSadrzaj dokumentSadrzaj = db.DokumentSadrzaji.Find(id);
            if (dokumentSadrzaj == null)
            {
                return HttpNotFound();
            }
            return View(dokumentSadrzaj);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Naziv,Datum,Kolicina,TipUlaza")] DokumentSadrzaj dokumentSadrzaj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dokumentSadrzaj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dokumentSadrzaj);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DokumentSadrzaj dokumentSadrzaj = db.DokumentSadrzaji.Find(id);
            if (dokumentSadrzaj == null)
            {
                return HttpNotFound();
            }
            return View(dokumentSadrzaj);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DokumentSadrzaj dokumentSadrzaj = db.DokumentSadrzaji.Find(id);
            db.DokumentSadrzaji.Remove(dokumentSadrzaj);
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

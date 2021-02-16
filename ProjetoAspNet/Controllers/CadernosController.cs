using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoAspNet.Data;
using ProjetoAspNet.Domain;

namespace ProjetoAspNet.Controllers
{
    [Authorize]
    public class CadernosController : Controller
    {
        private SistemaDbContext db = new SistemaDbContext();

        // GET: Cadernos
        public ActionResult Index()
        {
            return View(db.Cadernoes.ToList());
        }

        // GET: Cadernos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caderno caderno = db.Cadernoes.Find(id);
            if (caderno == null)
            {
                return HttpNotFound();
            }
            return View(caderno);
        }

        // GET: Cadernos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadernos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CadernoId,Nome,Descricao")] Caderno caderno)
        {
            if (ModelState.IsValid)
            {
                db.Cadernoes.Add(caderno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(caderno);
        }

        // GET: Cadernos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caderno caderno = db.Cadernoes.Find(id);
            if (caderno == null)
            {
                return HttpNotFound();
            }
            return View(caderno);
        }

        // POST: Cadernos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CadernoId,Nome,Descricao")] Caderno caderno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caderno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(caderno);
        }

        // GET: Cadernos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Caderno caderno = db.Cadernoes.Find(id);
            if (caderno == null)
            {
                return HttpNotFound();
            }
            return View(caderno);
        }

        // POST: Cadernos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Caderno caderno = db.Cadernoes.Find(id);
            db.Cadernoes.Remove(caderno);
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

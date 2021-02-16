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
    public class NotasController : Controller
    {
        private SistemaDbContext db = new SistemaDbContext();

        // GET: Notas
        public ActionResult Index()
        {
            return View(db.Notas.ToList());
        }

        // GET: Notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            ViewBag.Cadernos = new SelectList
                (
                    ListCadernos(), "CadernoId", "Nome"
                );
            return View();
        }

        // POST: Notas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NotasId,Titulo,Tag,DataDaCriacao,Conteudo")] Notas notas, string cadernos)
        {
            ViewBag.Cadernos = new SelectList
                (
                    ListCadernos(), "CadernoId", "Nome", cadernos
                );

            Caderno caderno = db.Cadernoes.Find(Int32.Parse(cadernos));

            //E adicionamos este curso ao aluno
            notas.Cadernos.Add(caderno);
            if (ModelState.IsValid)
            {
                db.Notas.Add(notas);
                db.SaveChanges();
                return RedirectToAction("Index", "Cadernos");
            }

            return View(notas);
        }

        private IEnumerable<Caderno> ListCadernos()
        {
            return db.Cadernoes.ToList();
        }

        // GET: Notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // POST: Notas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NotasId,Titulo,Tag,DataDaCriacao,Conteudo")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Cadernos");
            }
            return View(notas);
        }

        // GET: Notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notas notas = db.Notas.Find(id);
            db.Notas.Remove(notas);
            db.SaveChanges();
            return RedirectToAction("Index", "Cadernos");
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PJGPlantasMVC.Models;

namespace PJGPlantasMVC
{
    public class BoletoController : Controller
    {
        private PjgContext db = new PjgContext();

        // GET: Boleto
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var boletos = from s in db.Boleto
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                boletos = boletos.Where(s => s.Nome.Contains(searchString));

            }
            return View(boletos.ToList());
        }

        // GET: Boleto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                return HttpNotFound();
            }
            return View(boleto);
        }

        // GET: Boleto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boleto/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                db.Boleto.Add(boleto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boleto);
        }

        // GET: Boleto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                return HttpNotFound();
            }
            return View(boleto);
        }

        // POST: Boleto/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boleto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boleto);
        }

        // GET: Boleto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleto boleto = db.Boleto.Find(id);
            if (boleto == null)
            {
                return HttpNotFound();
            }
            return View(boleto);
        }

        // POST: Boleto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boleto boleto = db.Boleto.Find(id);
            db.Boleto.Remove(boleto);
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
